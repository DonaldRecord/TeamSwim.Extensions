using JetBrains.Annotations;

namespace System.Reflection
{
    partial class TypeExt
    {
        /// <summary>
        ///     Determines if a custom attribute of a specified type is applied to a specified member.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to seek on <paramref name="type"/>.</typeparam>
        /// <param name="type">Type to be seeked for parameter.</param>
        /// <param name="attribute">The custom attribute, if found.</param>
        /// <returns><see langword="true"/> if the attribute exists on the type. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="AmbiguousMatchException">Throws when multiple attributes of same type are found.</exception>
        [PublicAPI]
        public static bool HasCustomAttribute<TAttribute>(
            [NotNull] this Type type, 
            [CanBeNull] out TAttribute attribute) where TAttribute : Attribute
        {
            attribute = type.GetCustomAttribute<TAttribute>();
            var result = attribute != null;
            return result;
        }

        /// <summary>
        ///     Determines if a custom attribute of a specified type is applied to a specified member.
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type to seek on <paramref name="type"/>.</typeparam>
        /// <param name="type">Type to be seeked for parameter.</param>
        /// <returns><see langword="true"/> if the attribute exists on the type. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="AmbiguousMatchException">Throws when multiple attributes of same type are found.</exception>
        [PublicAPI]
        public static bool HasCustomAttribute<TAttribute>([NotNull] this Type type) where TAttribute : Attribute
            => type.HasCustomAttribute<TAttribute>(out _);
    }
}
