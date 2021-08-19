using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Conditionally appends the specified <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">The sequence to conditionally append an element to.</param>
        /// <param name="predicate">Flag dictating if the element should be added or not.</param>
        /// <param name="element">The element to conditionally add to the sequence.</param>
        /// <returns>The source collection with the conditionally appended element.</returns>
        [PublicAPI]
        [Pure, LinqTunnel, NotNull, ItemCanBeNull]
        public static IEnumerable<T> AppendIf<T>(
            [NotNull] this IEnumerable<T> source, 
            bool predicate, 
            [CanBeNull] T element)
        {
            if (predicate)
                return source.Append(element);
            else
                return source;
        }
    }
}
