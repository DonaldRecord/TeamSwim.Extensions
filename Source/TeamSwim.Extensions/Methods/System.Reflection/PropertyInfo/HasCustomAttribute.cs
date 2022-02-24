using JetBrains.Annotations;

namespace System.Reflection
{
    partial class PropertyInfoExt
    {
        /// <summary>
        ///     Determines if a custom attribute of a specified property is applied to a specified member.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to seek on <paramref name="property"/>.</typeparam>
        /// <param name="property">Type to be seeked for parameter.</param>
        /// <param name="attribute">The custom attribute, if found.</param>
        /// <returns><see langword="true"/> if the attribute exists on the property. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="AmbiguousMatchException">Throws when multiple attributes of same type are found.</exception>
        [PublicAPI]
        public static bool HasCustomAttribute<TAttribute>(
            [NotNull] this PropertyInfo property,
            [CanBeNull] out TAttribute attribute) where TAttribute : Attribute
        {
            attribute = property.GetCustomAttribute<TAttribute>();
            var result = attribute != null;
            return result;
        }

        /// <summary>
        ///     Determines if a custom attribute of a specified property is applied to a specified member.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to seek on <paramref name="property"/>.</typeparam>
        /// <param name="property">Type to be seeked for parameter.</param>
        /// <returns><see langword="true"/> if the attribute exists on the property. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="AmbiguousMatchException">Throws when multiple attributes of same type are found.</exception>
        [PublicAPI]
        [Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static bool HasCustomAttribute<TAttribute>([NotNull] this PropertyInfo property) where TAttribute : Attribute
            => property.HasCustomAttribute<TAttribute>(out _);
    }
}
