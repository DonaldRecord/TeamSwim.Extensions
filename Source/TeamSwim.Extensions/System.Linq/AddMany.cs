using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Linq
{
    /// <summary>
    ///     Linq extension method class.
    /// </summary>
    public static partial class LinqExt
    {
        /// <summary>
        ///     Loops set of new elements to add them to an existing collection.
        /// </summary>
        /// <typeparam name="TElement">Element type of collection.</typeparam>
        /// <param name="source">The collection being added to.</param>
        /// <param name="addElements">The source list of elements.</param>
        /// <param name="excludeNullElements">If <see langword="true"/>, will skip over <see langword="null"/> elements.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/></exception>
        [PublicAPI]
        public static void AddMany<TElement>(
            [NotNull] this ICollection<TElement> source,
            [CanBeNull, InstantHandle, ItemCanBeNull] IEnumerable<TElement> addElements,
            bool excludeNullElements = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (addElements == null) return;

            foreach (var elem in addElements)
            {
                var add = elem != null || !excludeNullElements;
                if (add)
                    source.Add(elem);
            }
        }
    }
}