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
        ///     Asserts that all elements in a sequence are distinct (ignoring null values).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="source">The sequence to assert.</param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel]
        public static IEnumerable<T> AssertDistinct<T>(
            this IEnumerable<T> source, 
            EqualityComparer<T> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var tmp = new List<T>();
            comparer = comparer ?? EqualityComparer<T>.Default;

            foreach (var elem in source)
            {
                if (elem != null)
                {
                    if (tmp.Contains(elem, comparer))
                        throw new NotImplementedException();

                    tmp.Add(elem);
                }

                yield return elem;
            }
        }
    }
}
