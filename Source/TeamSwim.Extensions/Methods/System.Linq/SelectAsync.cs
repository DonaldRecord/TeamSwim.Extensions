//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace System.Linq
//{
//#if NETCOREAPP3_1
//    partial class LinqExt
//    {
//        public static IAsyncEnumerable<TResult> SelectAsync<T, TResult>(this IEnumerable<T> enumerable,
//            Func<T, Task<TResult>> selector)
//        {
//            //return AsyncEnumerable.CreateEnumerable(() =>
//            //{
//            //    var enumerator = enumerable.GetEnumerator();
//            //    var current = default(TResult);
//            //    return AsyncEnumerable.CreateEnumerator(async c =>
//            //        {
//            //            var moveNext = enumerator.MoveNext();
//            //            current = moveNext
//            //                ? await selector(enumerator.Current).ConfigureAwait(false)
//            //                : default(TResult);
//            //            return moveNext;
//            //        },
//            //        () => current,
//            //        () => enumerator.Dispose());
//            //});
//        }
//    }
//#endif
//}
