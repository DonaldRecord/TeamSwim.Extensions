using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Get the cartesian product of two collections.
        ///     If the second collection is empty, the <paramref name="fallbackSelector"/> parameter is
        ///     evaluated to provide a result; otherwise, it will be empty.
        /// </summary>
        /// <typeparam name="T">First collection element type.</typeparam>
        /// <typeparam name="TSecond">Second collection element type.</typeparam>
        /// <typeparam name="TValue">Return type.</typeparam>
        /// <param name="source">First collection in cross join.</param>
        /// <param name="cross">Second collection in cross join.</param>
        /// <param name="selector">A transform function to apply to each cross-joined set of elements.</param>
        /// <param name="fallbackSelector">Function that is evaluated when the second collection is empty.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel]
        public static IEnumerable<TValue> CrossJoin<T, TSecond, TValue>(
            [NotNull, InstantHandle, ItemCanBeNull] this IEnumerable<T> source,
            [NotNull, ItemCanBeNull] ICollection<TSecond> cross,
            [NotNull, InstantHandle] Func<T, TSecond, TValue> selector,
            [InstantHandle] Func<T, TValue> fallbackSelector = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (cross == null) throw new ArgumentNullException(nameof(cross));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            if (cross.Any())
            {
                foreach (var elem in source)
                {
                    foreach (var c in cross)
                    {
                        var result = selector.Invoke(elem, c);
                        yield return result;
                    }
                }
            }
            else if (fallbackSelector != null)
            {
                foreach (var elem in source)
                {
                    var result = fallbackSelector.Invoke(elem);
                    yield return result;
                }
            }
        }
    }
}
