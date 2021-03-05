using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Returns the first element of a sequence that satisfies one of the predicates.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="predicates">Predicates to evaluate for returning an element.</param>
        /// <returns>The first element to satisfy one of the predicates.</returns>
        [PublicAPI]
        [Pure]
        public static T FirstCoalesce<T>(this IEnumerable<T> source, params Func<T, bool>[] predicates)
        {
            var matches = new List<Tuple<int, T>>();

            foreach (var elem in source)
            {
                var i = 0;
                foreach (var predicate in predicates)
                {
                    var match = predicate.Invoke(elem);
                    if (match)
                    {
                        if (i == 0)
                            return elem;
                        else
                            matches.Add(new Tuple<int, T>(i, elem));
                    }

                    i++;
                }
            }

            var tuple = matches.OrderBy(m => m.Item1).First();
            return tuple.Item2;
        }
    }
}
