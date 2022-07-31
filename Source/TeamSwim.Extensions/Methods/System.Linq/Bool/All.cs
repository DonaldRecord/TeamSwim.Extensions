using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Determines if all elements are <see langword="true"/>.
        /// </summary>
        /// <param name="source">Sequence of <see cref="bool"/>.</param>
        /// <returns><see langword="true"/> if all elements are <see langword="null"/>. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool All([NotNull] this IEnumerable<bool> source) => source.All(_ => _);
    }
}
