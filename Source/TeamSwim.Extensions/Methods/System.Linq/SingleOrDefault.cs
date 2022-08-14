using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Returns the only element of a sequence, or a default value if the sequence is empty; 
        ///     this method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">Sequence to return the single element of.</param>
        /// <param name="manyError">Custom error to throw when the sequence contains more than one element.</param>
        /// <returns>The single element of the input sequence.</returns>
        [PublicAPI]
        [Pure]
        public static T SingleOrDefault<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            Exception manyError)
        {
            if (source == null)
                throw Exceptions.ArgumentNull(nameof(source));
            
            var elems = source.Take(2).ToList();
            if (elems.Count == 2)
                throw manyError;

            return elems.SingleOrDefault();
        }

        /// <summary>
        ///     Returns the only element of a sequence, or a default value if the sequence is empty; 
        ///     this method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">Sequence to return the single element of.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <param name="manyError">Custom error to throw when the sequence contains more than one element.</param>
        /// <returns>The single element of the input sequence.</returns>
        [PublicAPI]
        [Pure]
        public static T SingleOrDefault<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [NotNull, InstantHandle] Func<T, bool> predicate,
            Exception manyError)
        {
            if (source == null) 
                throw Exceptions.ArgumentNull(nameof(source));

            if (manyError == null)
                return source.SingleOrDefault(predicate);
            
            var elems = source.Take(2).ToList();
            if (elems.Count == 2)
                throw manyError;

            return elems.SingleOrDefault();
        }
    }
}