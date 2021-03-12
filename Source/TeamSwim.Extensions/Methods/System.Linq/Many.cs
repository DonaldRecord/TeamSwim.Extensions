using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Determines if there is more than one element in the array.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="predicate">Predicate to filter elements in the sequence before checking count</param>
        /// <returns><see langword="true"/> if there is more than one element in the array. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool Many<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source, 
            [CanBeNull, InstantHandle] Func<T, bool> predicate = null)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (predicate == null && source is ICollection<T> collection)
                return collection.Count > 1;

            else
            {
                predicate ??= _ => true;
                var count = source.Count(predicate);
                return count > 1;
            }
        }
    }
}
