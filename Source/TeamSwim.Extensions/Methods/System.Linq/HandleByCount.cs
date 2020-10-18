﻿using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Shorthand method for handling a source collection based on how many elements it has.
        ///     (None, one, or many)
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source"></param>
        /// <param name="noItemsHandler"></param>
        /// <param name="singleItemHandler"></param>
        /// <param name="manyItemsHandler"></param>
        [PublicAPI]
        public static void HandleByCount<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [CanBeNull, InstantHandle] Action noItemsHandler = null,
            [CanBeNull, InstantHandle] Action<T> singleItemHandler = null,
            [CanBeNull, InstantHandle] Action<ICollection<T>> manyItemsHandler = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var list = source.ToList();
            if (!list.Any())
                noItemsHandler?.Invoke();
            else if (list.Count == 1)
                singleItemHandler?.Invoke(list.Single());
            else
                manyItemsHandler?.Invoke(list);
        }
    }
}