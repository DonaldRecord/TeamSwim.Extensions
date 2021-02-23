//using System;
//using System.Collections.Generic;
//using System.Text;
//using JetBrains.Annotations;
//using TeamSwim;

//namespace System.Linq
//{
//    partial class LinqExt
//    {
//        [PublicAPI]
//        [Pure]
//        public static T Single<T>(
//            [NotNull, InstantHandle] this IEnumerable<T> source, 
//            [NotNull, InstantHandle] Func<T, bool> predicate, 
//            [CanBeNull] Exception singleError = null,
//            [CanBeNull] Exception manyError = null)
//        {
//            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

//            var elems = source.Take(2).ToList();
//            if (elems.Count == 0)
//                throw singleError ?? ErrorNoMatch();
//            if (elems.Count == 2)
//                throw manyError ?? ErrorMoreThanOneMatch();
            
//            return elems.Single();
//        }
//    }
//}
