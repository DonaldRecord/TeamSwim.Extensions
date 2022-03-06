using System.Collections.Generic;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Determines if all elements are <see langword="true"/>.
        /// </summary>
        /// <param name="source">Sequence of <see cref="bool"/>.</param>
        /// <returns><see langword="true"/> if all elements are <see langword="null"/>. Otherwise, <see langword="false"/>.</returns>
        public static bool All(this IEnumerable<bool> source) => source.All(_ => _);
    }
}
