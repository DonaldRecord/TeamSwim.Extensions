using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace System.Reflection
{
    partial class PropertyInfoExt
    {
        /// <summary>
        ///     Determines if a collection of custom attribute of a specified type is applied to a specified property.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to seek on <paramref name="property"/>.</typeparam>
        /// <param name="property">Type to be seeked for parameter.</param>
        /// <param name="attributes">The custom attributes, if found.</param>
        /// <returns><see langword="true"/> if any attributes exist on the property. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        public static bool HasCustomAttributes<TAttribute>(
            [NotNull] this PropertyInfo property,
            [NotNull] out ICollection<TAttribute> attributes) where TAttribute : Attribute
        {
            attributes = property.GetCustomAttributes<TAttribute>().ToList();
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
        [Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static bool HasCustomAttributes<TAttribute>([NotNull] this Type type) where TAttribute : Attribute
            => type.HasCustomAttributes<TAttribute>(out _);
    }
}