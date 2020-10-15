using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>Determines whether all elements of a sequence satisfy a condition.</summary>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>
        /// <see langword="true" /> if every element of the source sequence passes the test in the specified predicate, or if the sequence is empty; otherwise, <see langword="false" />.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="predicate" /> is <see langword="null" />.</exception>
        [PublicAPI]
        [Pure]
        public static bool All<T>(
            [InstantHandle, NotNull] this IEnumerable<T> source,
            [InstantHandle, NotNull] Func<T, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var i = 0;
            foreach (var elem in source)
            {
                var passed = predicate.Invoke(elem, i);
                if (!passed)
                    return false;
                i++;
            }

            return true;
        }
    }
}
