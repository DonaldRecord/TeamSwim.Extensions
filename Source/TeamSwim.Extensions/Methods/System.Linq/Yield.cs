using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Create a sequence from a single element. Will not throw for <see langword="null"/> values.
        /// </summary>
        /// <typeparam name="T">Type of destination sequence.</typeparam>
        /// <param name="element">Object that become the first element in the destination sequence.</param>
        /// <returns><see cref="IEnumerable{T}"/> with one element.</returns>
        [Pure, NotNull, LinqTunnel]
        [PublicAPI]
        public static IEnumerable<T> Yield<T>([CanBeNull] this T element)
        {
            yield return element;
        }
    }
}
