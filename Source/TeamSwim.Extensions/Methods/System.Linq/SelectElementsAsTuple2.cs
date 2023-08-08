//using System;
//using System.Collections.Generic;
//using System.Text;
//using JetBrains.Annotations;

//namespace System.Linq
//{
//    partial class LinqExt
//    {
//        /// <summary>
//        ///     (Opinionated)
//        ///     Construct a <see cref="Tuple{T, T}"/> from elements inside the source array.
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="source"></param>
//        /// <param name="a"></param>
//        /// <param name="b"></param>
//        /// <returns></returns>
//        [PublicAPI]
//        [Pure, NotNull]
//        public static Tuple<T, T> SelectElementsAsTuple<T>(
//            [NotNull] this IEnumerable<T> source, 
//            int a, int b)
//        {
//            var x = source.ElementAtOrDefault(a);
//            var y = source.ElementAtOrDefault(b);
//            return Tuple.Create(x, y);
//        }
//    }
//}
