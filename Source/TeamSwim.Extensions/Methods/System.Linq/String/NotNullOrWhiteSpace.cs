using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Returns elements from the <paramref name="source"/> that are not null or white space.
        /// </summary>
        /// <param name="source">Source collection to iterate.</param>
        /// <returns>Set of elements that are not null or white space.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<string> NotNullOrWhiteSpace([NotNull, ItemCanBeNull] this IEnumerable<string> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Where(x => !String.IsNullOrWhiteSpace(x));
        }
    }
}
