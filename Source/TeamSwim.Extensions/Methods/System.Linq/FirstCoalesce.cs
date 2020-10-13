using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
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
