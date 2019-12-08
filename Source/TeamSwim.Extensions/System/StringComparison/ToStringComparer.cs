using JetBrains.Annotations;
using System.Collections.Generic;

namespace System
{
    /// <summary>
    ///     Extension method class for <see cref="StringComparison"/>.
    /// </summary>
    public static partial class StringComparisonExt
    {
        private static readonly Dictionary<StringComparison, Func<StringComparer>> _maps =
            new Dictionary<StringComparison, Func<StringComparer>>
            {
                {StringComparison.CurrentCulture, () => StringComparer.CurrentCulture},
                {StringComparison.CurrentCultureIgnoreCase, () => StringComparer.CurrentCultureIgnoreCase},
                {StringComparison.InvariantCulture, () => StringComparer.InvariantCulture},
                {StringComparison.InvariantCultureIgnoreCase, () => StringComparer.InvariantCultureIgnoreCase},
                {StringComparison.Ordinal, () => StringComparer.Ordinal},
                {StringComparison.OrdinalIgnoreCase, () => StringComparer.OrdinalIgnoreCase}
            };

        /// <summary>
        ///     Return equivalent <see cref="StringComparer"/> of the specified <paramref name="stringComparison"/>.
        /// </summary>
        /// <param name="stringComparison">String comparison.</param>
        /// <returns>Equivalent <see cref="StringComparer"/> type.</returns>
        [Pure, NotNull, PublicAPI, Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static StringComparer ToStringComparer(this StringComparison stringComparison) => _maps[stringComparison]();

        /// <summary>
        ///     Return equivalent <see cref="StringComparer"/> of the specified <paramref name="stringComparison"/>.
        /// </summary>
        /// <param name="stringComparison">String comparison.</param>
        /// <param name="defaultComparer">Default comparer to return if no equivalent <see cref="StringComparer"/> is found.</param>
        /// <returns>Equivalent <see cref="StringComparer"/> type.</returns>
        [Pure, NotNull, PublicAPI]
        public static StringComparer ToStringComparer(this StringComparison stringComparison, [NotNull] StringComparer defaultComparer)
        {
            if (_maps.ContainsKey(stringComparison))
                return _maps[stringComparison]();
            else
                return defaultComparer;
        }
    }
}
