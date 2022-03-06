using System.Collections.Generic;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Determines whether any element is <see langword="true"/>.
        /// </summary>
        /// <param name="source">Sequence of <see cref="bool"/>.</param>
        /// <returns><see langword="true"/> if any element is <see langword="null"/>. Otherwise, <see langword="false"/>.</returns>
        public static bool Any(this IEnumerable<bool> source) => source.Any(_ => _);
    }
}
