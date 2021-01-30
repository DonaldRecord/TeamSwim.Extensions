using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        [PublicAPI]
        [NotNull, ItemCanBeNull, LinqTunnel]
        public static IEnumerable<IEnumerable<TValue>> Expand<T, TValue>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [ItemNotNull] params Func<T, TValue>[] expanders)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var elem in source)
            {
                yield return ExpandElement(elem, expanders);
            }
        }

        [PublicAPI]
        [NotNull, ItemCanBeNull, LinqTunnel]
        public static IEnumerable<TValue> ExpandMany<T, TValue>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [ItemNotNull] params Func<T, TValue>[] expanders)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var elem in source)
            {
                foreach (var result in ExpandElement(elem, expanders))
                    yield return result;
            }
        }

        private static IEnumerable<TValue> ExpandElement<T, TValue>(T element, IEnumerable<Func<T, TValue>> expanders)
        {
            foreach (var expander in expanders)
            {
                var result = expander.Invoke(element);
                yield return result;
            }
        }
    }
}
