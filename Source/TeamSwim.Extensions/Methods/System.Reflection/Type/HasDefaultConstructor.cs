using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace System.Reflection
{
    partial class TypeExt
    {
        private static Tuple<bool, ConstructorInfo> _hasDefaultConstructor([NotNull] this Type value, BindingFlags bindingFlags)
        {
            if (value.IsValueType) return new Tuple<bool, ConstructorInfo>(true, null);

            var ctor = value.GetConstructor(bindingFlags, null, Type.EmptyTypes, null);
            return new Tuple<bool, ConstructorInfo>(ctor != null, ctor);
        }

        /// <summary>
        ///     Determines if the specified type has a default constructor and returns the default constructor if it is found.
        ///     Value types will return true, but will not return any constructor.
        /// </summary>
        /// <param name="value">The type to check for default constructor in.</param>
        /// <param name="bindingFlags">The binding flags for searching the constructors.</param>
        /// <param name="ctor">The default constructor, if found.</param>
        /// <returns><see langword="true"/> if the type has a default constructor, otherwise <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool HasDefaultConstructor(
            [NotNull] this Type value,
            [CanBeNull] out ConstructorInfo ctor,
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            var result = _hasDefaultConstructor(value, bindingFlags);
            ctor = result.Item2;
            return result.Item1;
        }

        /// <summary>
        ///     Determines if the specified type has a default constructor and returns the default constructor if it is found.
        ///     Value types will return true, but will not return any constructor.
        /// </summary>
        /// <param name="value">The type to check for default constructor in.</param>
        /// <param name="bindingFlags">The binding flags for searching the constructors.</param>
        /// <returns><see langword="true"/> if the type has a default constructor, otherwise <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool HasDefaultConstructor(
            [NotNull] this Type value,
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            ConstructorInfo _;
            return HasDefaultConstructor(value, out _, bindingFlags);
        }
    }
}
