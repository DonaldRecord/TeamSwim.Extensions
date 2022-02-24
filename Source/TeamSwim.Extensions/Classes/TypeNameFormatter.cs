using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace System
{
    /// <summary>
    ///     Provides custom formatting of .NET Type Names.
    /// </summary>
    public interface ITypeNameFormatter
    {
        /// <summary>
        ///     Returns the formatted name of a type.
        /// </summary>
        /// <param name="t">Type to return name for.</param>
        /// <param name="options">Options for formatting returned type names.</param>
        /// <returns>Formatted type name string.</returns>
        [PublicAPI]
        [Pure, NotNull]
        string GetName([NotNull] Type t, TypeNameFormattingOptions options = TypeNameFormattingOptions.Default);
    }

    /// <summary>
    ///     Provides custom formatting of .NET Type names.
    /// </summary>
    public class TypeNameFormatter : ITypeNameFormatter
    {
        /// <summary>
        ///     Options available for formatting returned type names.
        /// </summary>
        public TypeNameFormattingOptions Options { get; }

        /// <summary>
        ///     Construct a new instance of <see cref="TypeNameFormatter"/>.
        /// </summary>
        public TypeNameFormatter() : this(TypeNameFormattingOptions.Default) { }
        
        /// <summary>
        ///     Construct a new instance of <see cref="TypeNameFormatter"/>.
        /// </summary>
        /// <param name="options">Options for formatting returned type names.</param>
        public TypeNameFormatter(TypeNameFormattingOptions options)
        {
            Options = options;
        }

        /// <summary>
        ///     Returns the formatted name of a type.
        /// </summary>
        /// <param name="t">Type to return name for.</param>
        /// <returns>Formatted type name string.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="t"/> is <see langword="null"/></exception>
        [PublicAPI]
        [Pure, NotNull]
        public string GetName([NotNull] Type t)
        {
            var result = GetName(t, Options);
            return result;
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            //if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(obj, null)) return false;
            if (GetType() != obj.GetType()) return false;

            var y = (TypeNameFormatter)obj;

            return Options == y.Options;
        }

        /// <summary>Serves as the default hash function.</summary>
        /// <returns>A hash code for the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode() => Options.GetHashCode();

        string ITypeNameFormatter.GetName(Type t, TypeNameFormattingOptions options) => 
            GetName(t, Options);

        /// <summary>
        ///     Returns the formatted name of a type.
        /// </summary>
        /// <param name="t">Type to return name for.</param>
        /// <param name="options">Formatting options on output string.</param>
        /// <returns>Formatted type name string.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="t"/> is <see langword="null"/></exception>
        //TODO: Implement "dynamic" tests
        [Pure, NotNull]
        // ReSharper disable once CyclomaticComplexity
        public static string GetName([NotNull] Type t, TypeNameFormattingOptions options)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            if (options == 0) return t.Name;

            var useQuestionMark = options.HasFlag(TypeNameFormattingOptions.UseQuestionMarkForNullable);
            var useKeyword = options.HasFlag(TypeNameFormattingOptions.UseKeywords);
            var fullyQualified = options.HasFlag(TypeNameFormattingOptions.FullyQualified);
            var useEnum = options.HasFlag(TypeNameFormattingOptions.UseEnumKeyword);
            var dynamic = options.HasFlag(TypeNameFormattingOptions.UseDynamicKeyword);

            //is a dynamic type
            if (dynamic && typeof(IDynamicMetaObjectProvider).IsAssignableFrom(t))
            {
                if (fullyQualified)
                    return typeof(DynamicObject).FullName;
                if (useKeyword)
                    return KeywordTransforms()[typeof(DynamicObject)];
                else
                    return nameof(DynamicObject);
            }

            if (useEnum && t.IsEnum)
            {
                // ReSharper disable once TailRecursiveCall
                return GetName(typeof(Enum), options);
            }
            if (t.IsArray)
            {
                var elementType = t.GetElementType();
                var rank = t.GetArrayRank();
                var commas = new string(',', rank - 1);
                // ReSharper disable once AssignNullToNotNullAttribute
                return $"{GetName(elementType, options)}[{commas}]";
            }

            if (!t.IsGenericType)
            {
                if (useKeyword)
                {
                    var transforms = KeywordTransforms();

                    if (transforms.ContainsKey(t))
                        return transforms[t];
                    else
                    {
                        if (fullyQualified)
                            return t.FullName;
                        else
                            return t.Name;
                    }
                }
                else
                {
                    if (fullyQualified)
                        return t.FullName;
                    else
                        return t.Name;
                }
            }

            var genT = t.GetGenericTypeDefinition();
            var genericTypeName = fullyQualified
                ? genT.FullName
                : genT.Name;
            genericTypeName = genericTypeName?.Substring(0, genericTypeName.IndexOf('`'));

            //TODO: This is the hog
            var genericArgs = t.GetGenericArguments();
            var args = String.Join(", ", genericArgs.Select(s => GetName(s, options)));

            var genericNameIsNullable = genT == typeof(Nullable<>);
            if (genericNameIsNullable)
            {
                if (useQuestionMark)
                {
                    var nullableResult = String.Concat(args, "?");
                    return nullableResult;
                }
                if (fullyQualified)
                    genericTypeName = "System.Nullable";
            }

            var result = $"{genericTypeName}<{args}>".Replace(", >", ",>");
            return result;
        }

        private static Dictionary<Type, string> KeywordTransforms() => new Dictionary<Type, string>
        {
            {typeof(Boolean), "bool"},
            {typeof(Byte), "byte"},
            {typeof(Char), "char"},
            {typeof(Decimal), "decimal"},
            {typeof(Double), "double"},
            {typeof(Enum), "enum"},
            {typeof(Int16), "short"},
            {typeof(Int32), "int"},
            {typeof(Int64), "long"},
            {typeof(Object), "object"},
            {typeof(SByte), "sbyte"},
            {typeof(Single), "float"},
            {typeof(String), "string"},
            {typeof(UInt16), "ushort"},
            {typeof(UInt32), "uint"},
            {typeof(UInt64), "ulong"},
            {typeof(void), "void"},
            {typeof(Delegate), "delegate"},
            {typeof(DynamicObject), "dynamic"}
        };
    }

}