using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Orders elements against a predicate, prioritizing elements that evaluate to <see langword="true"/> by putting them first.
        ///     Error handling is not done for running the predicate.
        /// </summary>
        /// <typeparam name="TElement">Type of element.</typeparam>
        /// <param name="source">Set of elements.</param>
        /// <param name="predicate">Predicate to evaluate elements against.</param>
        /// <returns></returns>
        [Pure, NotNull, LinqTunnel]
        [PublicAPI]
        public static IOrderedEnumerable<TElement> Prioritize<TElement>(
        [NotNull] this IEnumerable<TElement> source,
        [NotNull] Func<TElement, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
                if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var result = source.OrderByDescending(predicate);
                return result;
        }
    }
}
