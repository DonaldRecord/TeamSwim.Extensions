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
        ///     (Opinionated)
        ///     Creates an endless IEnumerable that is an infinite circular list.
        /// <para>
        ///     For instance, if the source is a list of integers [1, 2, 3]
        ///     and the element at index 3 is requested, normally an exception would be thrown.
        ///     With this extension method, it would loop back to the beginning and start again.
        ///     The source enumerable is immediately converted into an <see cref="ICollection{T}"/> to 
        /// </para>
        /// <para>
        ///     Iterating over this result will result in a <see cref="StackOverflowException"/>.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [PublicAPI]
        [NotNull, ItemCanBeNull, LinqTunnel]
        public static IEnumerable<T> ToCircularEnumerable<T>(
            [NotNull, ItemCanBeNull, InstantHandle] this IEnumerable<T> source)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            var enumerable = source.ToList();

            while (true)
            {
                foreach (var elem in enumerable)
                    yield return elem;
            }
        }
    }
}
