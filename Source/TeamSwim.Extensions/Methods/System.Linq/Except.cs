using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Filters the source sequence by eliminating elements that do not pass the predicate
        ///     (Is the inverse of the .Where extension method).
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source sequence.</param>
        /// <param name="predicate">Predicate to filter elements.</param>
        /// <returns>Filtered sequence.</returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel]
        public static IEnumerable<T> Except<T>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Func<T, bool> predicate)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (predicate == null) throw Exceptions.ArgumentNull(nameof(predicate));

            var result = source.Where(t => !predicate.Invoke(t));
            return result;
        }

        /// <summary>
        ///     Filters the source sequence by eliminating elements that do not pass the predicate
        ///     (Is the inverse of the .Where extension method).
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source sequence.</param>
        /// <param name="predicate">Predicate to filter elements.</param>
        /// <returns>Filtered sequence.</returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel]
        public static IEnumerable<T> Except<T>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Func<T, int, bool> predicate)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (predicate == null) throw Exceptions.ArgumentNull(nameof(predicate));

            var result = source.Where((t, i) => !predicate.Invoke(t, i));
            return result;
        }
    }
}
