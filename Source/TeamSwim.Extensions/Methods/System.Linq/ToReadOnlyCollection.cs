﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Create a readonly collection.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="source">Source to create readonly collection from.</param>
        /// <returns>The new readonly collection.</returns>
        [PublicAPI]
        [Pure, NotNull]
        public static IReadOnlyCollection<T> ToReadOnlyCollection<T>([NotNull, InstantHandle] this IEnumerable<T> source)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            var list = source.ToList();
            var result = new ReadOnlyCollection<T>(list);
            return result;
        }
    }
}
