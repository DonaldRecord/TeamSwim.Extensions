//using System;
//using System.Collections.Generic;
//using System.Text;
//using JetBrains.Annotations;
//// ReSharper disable ConvertToNullCoalescingCompoundAssignment

//namespace System.Linq
//{
//    partial class LinqExt
//    {
//        [PublicAPI]
//        public static TResult SelectByCount<T, TResult>(
//            [NotNull, InstantHandle] this IEnumerable<T> source,
//            [CanBeNull, InstantHandle] Func<TResult> none = null,
//            [CanBeNull, InstantHandle] Func<T, TResult> one = null,
//            [CanBeNull, InstantHandle] Func<ICollection<T>, TResult> many = null)
//        {
//            if (source == null) throw new ArgumentNullException(nameof(source));
//            none = none ?? (() => default);
//            one = one ?? (_ => default);
//            many = many ?? (_ => default);

//            var list = source.ToList();
//            if (!list.Any())
//                return none.Invoke();
//            else if (list.Count == 1)
//                return one.Invoke(list.Single());
//            else
//                return many.Invoke(list);
//        }
//    }
//}