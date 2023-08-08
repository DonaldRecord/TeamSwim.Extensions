using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Returns the <paramref name="source"/> sequence if it is not <see langword="null"/>
        ///     or <c>Enumerable.Empty&lt;<typeparamref name="T"/>&gt;</c> if it is.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Sequence to check/return.</param>
        /// <returns><paramref name="source"/> or <c>Enumerable.Empty&lt;<typeparamref name="T"/>&gt;</c></returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel]
        public static IEnumerable<T> OrEmpty<T>([CanBeNull] this IEnumerable<T> source) => source ?? Enumerable.Empty<T>();
    }
}
