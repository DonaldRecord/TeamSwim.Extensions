﻿using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Returns a collection with any <see langword="null" /> elements removed.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T> source)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            foreach (var elem in source)
                if (elem != null)
                    yield return elem;
        }
    }
}
