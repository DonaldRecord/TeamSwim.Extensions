using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using TeamSwim;
using TeamSwim.Extensions.Classes;

namespace System.Reflection
{
    /// <summary>
    ///     Options for <see cref="TypeFinder.FindType(string, TypeFinderOptions)"/>.
    /// </summary>
    [PublicAPI]
    public class TypeFinderOptions
    {
        /// <summary>
        ///     Delegate to return an enumeration of types to search through for a <see cref="Type"/> result.
        /// </summary>
        public Func<IEnumerable<Type>> TypeProvider { get; set; } = () => CurrentDomainCache.Types;
        
        // TODO: manual entries
    }

    /// <summary>
    ///     (Opinionated)
    ///     Facade for figuring out a <see cref="Type" /> reference from a string input.
    /// </summary>
    [PublicAPI]
    public static class TypeFinder
    {
        /// <summary>
        ///     Find type based on a string input using the provided <paramref name="options"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Type FindType(string type, TypeFinderOptions options = null)
        {
            if (type == null) throw Exceptions.ArgumentNull(nameof(type));
            options = options ?? new TypeFinderOptions();
            if (options.TypeProvider == null)
                throw new ArgumentException("Type finder function was not provided in the type finder options.", nameof(options)).WithSource();

            var typeName = TypeName.Parse(type);
            if (!typeName.IsGeneric || typeName.IsOpenGeneric)
            {
                var result = GetAtomicType(typeName, options);
                return result;
            }
            else
            {
                var result = GetAtomicType(typeName, options);
                var args = typeName.TypeArguments.Select(arg => FindType(arg.ToString())).ToList();
                result = result.MakeGenericType(args.ToArray());
                return result;
            }
        }

        private static Type GetAtomicType(TypeName typeName, TypeFinderOptions options)
        {
            var canFind =
                CanFindKeyword(typeName, out var result) ||
                CanFindSingleType(typeName, options.TypeProvider, out result);
            if (!canFind)
                throw new ArgumentException($"No type could be found with identifier {typeName}").WithSource();

            if (typeName.ContainsNullableShorthand && result.IsValueType)
            {
                result = typeof(Nullable<>).MakeGenericType(result);
            }

            if (typeName.IsArray)
            {
                foreach (var t in typeName.ArrayDimensions.Reverse())
                {
                    if (t.Dimensions == 1)
                        result = result.MakeArrayType();
                    else
                        result = result.MakeArrayType(t.Dimensions);
                }
            }

            return result;
        }

        private static bool CanFindSingleType(TypeName typeName, Func<IEnumerable<Type>> enumerateTypes, out Type value)
        {
            var name = typeName.Name.Replace("?", "");

            // search by name, case sensitive
            var result = Type.GetType(name, false, false);
            if (result != null)
            {
                value = result;
                return true;
            }

            // search by name, case insensitive
            result = Type.GetType(name, false, true);
            if (result != null)
            {
                value = result;
                return true;
            }

            var types = enumerateTypes.Invoke();
            if (typeName.IsGeneric)
                types = types.Where(t => t.GetGenericArguments().Count() == typeName.TypeArguments.Count);

            var typeMatches = types
                .Select(t => TypeNameMatchup.Create(name, t))
                .OrderByDescending(tm => tm.MatchWeight)
                .ToListWhenDebugging();
            var typeMatch = typeMatches.FirstOrDefault();

            value = typeMatch?.Type;
            return value != null;
        }

        private static bool CanFindKeyword(TypeName typeName, out Type value)
        {
            var type = typeName.Name.Replace("?", "");
            value = FindKeyword(type);
            return value != null;
        }

        private static Type FindKeyword(string type)
        {
            switch (type)
            {
                case "string":
                    return typeof(string);
                case "sbyte":
                    return typeof(sbyte);
                case "byte":
                    return typeof(byte);
                case "short":
                    return typeof(short);
                case "ushort":
                    return typeof(ushort);
                case "int":
                    return typeof(int);
                case "uint":
                    return typeof(uint);
                case "long":
                    return typeof(long);
                case "ulong":
                    return typeof(ulong);
                case "char":
                    return typeof(char);
                case "float":
                    return typeof(float);
                case "double":
                    return typeof(double);
                case "bool":
                    return typeof(bool);
                case "decimal":
                    return typeof(decimal);
                case "void":
                    return typeof(void);
                case "object":
                    return typeof(object);
                default:
                    return null;
            }
        }

        private class TypeNameMatchup
        {
            private const string GENERIC_NAME_REGEX = @"`([0-9]*)$";

            public Type Type { get; }
            public int MatchWeight { get; private set; }

            public TypeNameMatchup(string input, Type type)
            {
                Type = type;
                if (type.FullName != null)
                {
                    IsFullNameCaseSensitiveMatch = type.FullName.Equals(input, StringComparison.Ordinal);
                    IsFullNameCaseInsensitiveMatch = type.FullName.Equals(input, StringComparison.OrdinalIgnoreCase);
                    AddWeight(IsFullNameCaseSensitiveMatch, IsFullNameCaseSensitiveMatchWeight);
                    AddWeight(IsFullNameCaseInsensitiveMatch, IsFullNameCaseInsensitiveMatchWeight);
                }

                IsNameCaseSensitiveMatch = type.Name.Equals(input, StringComparison.Ordinal);
                IsNameCaseInsensitiveMatch = type.Name.Equals(input, StringComparison.OrdinalIgnoreCase);
                AddWeight(IsNameCaseSensitiveMatch, IsNameCaseSensitiveMatchWeight);
                AddWeight(IsNameCaseInsensitiveMatch, IsNameCaseInsensitiveMatchWeight);

                if (Regex.IsMatch(type.Name, GENERIC_NAME_REGEX))
                {
                    var genericName = Regex.Replace(type.Name, GENERIC_NAME_REGEX, "");
                    IsGenericNameCaseSensitiveMatch = genericName.Equals(input, StringComparison.Ordinal);
                    IsGenericNameCaseInsensitiveMatch = genericName.Equals(input, StringComparison.OrdinalIgnoreCase);
                    AddWeight(IsGenericNameCaseSensitiveMatch, IsGenericNameCaseSensitiveMatchWeight);
                    AddWeight(IsGenericNameCaseInsensitiveMatch, IsGenericNameCaseInsensitiveMatchWeight);
                }

                if (type.FullName != null && Regex.IsMatch(type.FullName, GENERIC_NAME_REGEX))
                {
                    var genericFullName = Regex.Replace(type.Name, GENERIC_NAME_REGEX, "");
                    IsGenericFullNameCaseSensitiveMatch = genericFullName.Equals(input, StringComparison.Ordinal);
                    IsGenericFullNameCaseInsensitiveMatch = genericFullName.Equals(input, StringComparison.OrdinalIgnoreCase);
                    AddWeight(IsGenericFullNameCaseSensitiveMatch, IsGenericFullNameCaseSensitiveMatchWeight);
                    AddWeight(IsGenericFullNameCaseInsensitiveMatch, IsGenericFullNameCaseInsensitiveMatchWeight);
                }
            }

            public bool IsFullNameCaseSensitiveMatch { get; }
            private const int IsFullNameCaseSensitiveMatchWeight = 8;

            public bool IsFullNameCaseInsensitiveMatch { get; }
            public const int IsFullNameCaseInsensitiveMatchWeight = 7;

            public bool IsNameCaseSensitiveMatch { get; }
            public const int IsNameCaseSensitiveMatchWeight = 6;

            public bool IsNameCaseInsensitiveMatch { get; }
            public const int IsNameCaseInsensitiveMatchWeight = 5;

            public bool IsGenericFullNameCaseSensitiveMatch { get; }
            public const int IsGenericFullNameCaseSensitiveMatchWeight = 4;

            public bool IsGenericFullNameCaseInsensitiveMatch { get; }
            public const int IsGenericFullNameCaseInsensitiveMatchWeight = 3;

            public bool IsGenericNameCaseSensitiveMatch { get; }
            public const int IsGenericNameCaseSensitiveMatchWeight = 2;

            public bool IsGenericNameCaseInsensitiveMatch { get; }
            public const int IsGenericNameCaseInsensitiveMatchWeight = 1;

            private void AddWeight(bool add, int weight)
            {
                if (add)
                    MatchWeight += weight;
            }

            public static TypeNameMatchup Create(string input, Type type) => new TypeNameMatchup(input, type);
        }
    }
}
