using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">Sequence to return the single element of.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <param name="noneError">Custom error to throw when the sequence is empty.</param>
        /// <param name="manyError">Custom error to throw when the sequence contains more than one element.</param>
        /// <returns>The single element of the input sequence.</returns>
        [PublicAPI]
        [Pure]
        public static T Single<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [NotNull, InstantHandle] Func<T, bool> predicate,
            [CanBeNull] Exception noneError = null,
            [CanBeNull] Exception manyError = null)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            var elems = source.Take(2).ToList();
            if (elems.Count == 0)
                throw noneError ?? Exceptions.ErrorNoMatch();
            if (elems.Count == 2)
                throw manyError ?? Exceptions.ErrorMoreThanOneMatch();

            return elems.Single();
        }
    }
}
