﻿using JetBrains.Annotations;
using TeamSwim;

namespace System.Collections.Generic
{
    partial class CollectionExt
    {
        /// <summary>
        ///     Loops set of new elements to add them to an existing collection.
        /// </summary>
        /// <typeparam name="T">Element type of collection.</typeparam>
        /// <param name="source">The collection being added to.</param>
        /// <param name="addElements">The source list of elements.</param>
        /// <param name="excludeNullElements">(Opinionated) If <see langword="true"/>, will skip over <see langword="null"/> elements. Default is <see langword="false"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/></exception>
        [PublicAPI]
        public static void AddMany<T>(
            [NotNull] this ICollection<T> source,
            [CanBeNull, InstantHandle, ItemCanBeNull] IEnumerable<T> addElements,
            bool excludeNullElements = false)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
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