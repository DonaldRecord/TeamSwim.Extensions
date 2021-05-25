using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    partial class LinqExt
    {
        public static IEnumerable<Tuple<T1, T2>> SelectTuple<T, T1, T2>(
            this IEnumerable<T> source,
            Func<T, T1> item1,
            Func<T, T2> item2)
        {
            foreach (var elem in source)
            {
                var i1 = item1.Invoke(elem);
                var i2 = item2.Invoke(elem);
                var t = new Tuple<T1, T2>(i1, i2);
                yield return t;
            }
        }

        public static IEnumerable<Tuple<T1, T2>> SelectTuple<T, T1, T2>(
            this IEnumerable<T> source,
            Func<T, T1> item1,
            Func<T, T1, T2> item2)
        {
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
