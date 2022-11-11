using System.Collections.Generic;
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
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T> source) where T : class
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            foreach (var elem in source)
                if (elem != null)
                    yield return elem;
        }

        /// <summary>
        ///     Returns a collection of <typeparamref name="T"/> with <see langword="null" /> elements removed.
        /// <para>
        ///     Shorthand for <c>source.Where(elem => elem.HasValue).Select(elem => elem.Value)</c>
        /// </para>
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> source) where T : struct
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            foreach (var elem in source)
                if (elem != null)
                    yield return elem.Value;
        }
    }
}
