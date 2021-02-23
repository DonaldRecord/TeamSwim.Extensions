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
        ///     Projects multiple sequences, each containing an element and the result
        ///     of the element being passed through a set of <paramref name="expanders"/>.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="source">The sequence to expand.</param>
        /// <param name="expanders">The callbacks that will be applied to each element</param>
        /// <returns></returns>
        [PublicAPI]
        [NotNull, ItemCanBeNull, LinqTunnel]
        public static IEnumerable<IEnumerable<T>> Expand<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [ItemNotNull, InstantHandle] params Func<T, T>[] expanders)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            foreach (var elem in source)
                yield return ExpandElementImpl(elem, expanders);
        }

        /// <summary>
        ///     Projects a sequence containing the source elements as well as the evaluations of each element
        ///     against the passed <paramref name="expanders"/>.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="source">Source sequence to expand</param>
        /// <param name="expanders">Callbacks to expand each element</param>
        /// <returns></returns>
        [PublicAPI]
        [NotNull, ItemCanBeNull, LinqTunnel]
        public static IEnumerable<T> ExpandMany<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [ItemNotNull] params Func<T, T>[] expanders)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            foreach (var elem in source)
                foreach (var result in ExpandElementImpl(elem, expanders))
                    yield return result;
        }

        private static IEnumerable<T> ExpandElementImpl<T>(T element, IEnumerable<Func<T, T>> expanders)
        {
            yield return element;
            foreach (var expander in expanders)
            {
                var result = expander.Invoke(element);
                yield return result;
            }
        }
    }
}
