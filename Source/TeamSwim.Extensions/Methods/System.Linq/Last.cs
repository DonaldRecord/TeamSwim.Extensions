using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Returns the last element of a sequence, and throws an exception if there are no elements in the sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">Sequence to return the last element of.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <param name="noneError">Custom error to throw when the sequence is empty.</param>
        /// <returns>The last element of the input sequence.</returns>
        [PublicAPI]
        [Pure]
        public static T Last<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [NotNull, InstantHandle] Func<T, bool> predicate,
            [CanBeNull] Exception noneError = null)
        {
            if (source == null)
                throw Exceptions.ArgumentNull(nameof(source));

            var elems = source.Take(1).ToList();
            if (elems.Count == 0)
                throw noneError ?? Exceptions.ErrorNoMatch();

            return elems.Last();
        }
    }
}