using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Get the index of the first item in the <paramref name="sequence"/>
        ///     that passes the specified <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="sequence">Sequence to search.</param>
        /// <param name="predicate">Predicate to evaluate on sequence items.</param>
        /// <returns>First index of element passing predicate. Otherwise, -1.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure]
        public static int FirstIndexOf<T>(
            [NotNull, InstantHandle] this IEnumerable<T> sequence, 
            [NotNull, InstantHandle] Func<T, bool> predicate)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            
            var i = 0;
            foreach (var elem in sequence)
            {
                if (predicate.Invoke(elem))
                    return i;

                i++;
            }

            return -1;
        }
    }
}
