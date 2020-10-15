using System.Dynamic;
using JetBrains.Annotations;

namespace System
{
    /// <summary>
    ///     Extension method class for <see cref="Type"/>.
    /// </summary>
    public static partial class TypeExt
    {
        /// <summary>
        ///     Determines if a type is <see langword="dynamic"/>, and intended to be accessed via the .NET Dynamic API.
        ///     This method returns <see langword="false"/> for anonymous types.
        /// </summary>
        /// <param name="type">The type to be checked for dynamic.</param>
        /// <returns><see langword="true"/> if the type implements <see cref="IDynamicMetaObjectProvider"/>. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/></exception>
        [PublicAPI]
        [Pure]
        public static bool IsDynamic([NotNull] this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            var result = typeof(IDynamicMetaObjectProvider).IsAssignableFrom(type);
            return result;
        }
    }
}