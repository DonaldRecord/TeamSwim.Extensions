using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace System.Reflection
{
    partial class TypeExt
    {
        /// <summary>
        ///     Determines if a collection of custom attribute of a specified type is applied to a specified member.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to seek on <paramref name="type"/>.</typeparam>
        /// <param name="type">Type to be seeked for parameter.</param>
        /// <param name="attributes">The custom attributes, if found.</param>
        /// <returns><see langword="true"/> if any attributes exist on the type. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        public static bool HasCustomAttributes<TAttribute>(
            [JetBrains.Annotations.NotNull] this Type type,
            [JetBrains.Annotations.NotNull] out ICollection<TAttribute> attributes) where TAttribute : Attribute
        {
            attributes = type.GetCustomAttributes<TAttribute>().ToList();
            var result = attributes.Any();
            return result;
        }

        /// <summary>
        ///     Determines if a collection of custom attribute of a specified type is applied to a specified member.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to seek on <paramref name="type"/>.</typeparam>
        /// <param name="type">Type to be seeked for parameter.</param>
        /// <returns><see langword="true"/> if any attributes exist on the type. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [ExcludeFromCodeCoverage]
        public static bool HasCustomAttributes<TAttribute>([JetBrains.Annotations.NotNull] this Type type) where TAttribute : Attribute
            => type.HasCustomAttributes<TAttribute>(out _);
    }
}
