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
        ///     Select a <see cref="Tuple{T1, T2}"/> from a source sequence using transform functions.
        /// </summary>
        /// <typeparam name="T">Original element type.</typeparam>
        /// <typeparam name="T1">First destination tuple element type.</typeparam>
        /// <typeparam name="T2">Second destination tuple element type.</typeparam>
        /// <param name="source">Source sequence.</param>
        /// <param name="item1"><typeparamref name="T1"/> transform function.</param>
        /// <param name="item2"><typeparamref name="T2"/> transform function.</param>
        /// <returns>Transformed source sequence Enumerable.</returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel, ItemNotNull]
        public static IEnumerable<Tuple<T1, T2>> SelectTuple<T, T1, T2>(
            [NotNull] this IEnumerable<T> source,
            [NotNull, InstantHandle] Func<T, T1> item1,
            [NotNull, InstantHandle] Func<T, T2> item2)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (item1 == null) throw Exceptions.ArgumentNull(nameof(item1));
            if (item2 == null) throw Exceptions.ArgumentNull(nameof(item2));

            foreach (var elem in source)
            {
                var i1 = item1.Invoke(elem);
                var i2 = item2.Invoke(elem);
                var t = new Tuple<T1, T2>(i1, i2);
                yield return t;
            }
        }

        /// <summary>
        ///     Select a <see cref="Tuple{T1, T2}"/> from a source sequence using transform functions.
        /// </summary>
        /// <typeparam name="T">Original element type.</typeparam>
        /// <typeparam name="T1">First destination tuple element type.</typeparam>
        /// <typeparam name="T2">Second destination tuple element type.</typeparam>
        /// <param name="source">Source sequence.</param>
        /// <param name="item1"><typeparamref name="T1"/> transform function.</param>
        /// <param name="item2"><typeparamref name="T2"/> transform function.</param>
        /// <returns>Transformed source sequence Enumerable.</returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel, ItemNotNull]
        public static IEnumerable<Tuple<T1, T2>> SelectTuple<T, T1, T2>(
            this IEnumerable<T> source,
            Func<T, T1> item1,
            Func<T, T1, T2> item2)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (item1 == null) throw Exceptions.ArgumentNull(nameof(item1));
            if (item2 == null) throw Exceptions.ArgumentNull(nameof(item2));

            foreach (var elem in source)
            {
                var i1 = item1.Invoke(elem);
                var i2 = item2.Invoke(elem, i1);
                var t = new Tuple<T1, T2>(i1, i2);
                yield return t;
            }
        }
    }
}
