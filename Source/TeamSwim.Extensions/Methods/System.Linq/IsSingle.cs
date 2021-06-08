//using System;
//using System.Collections.Generic;
//using System.Text;
//using JetBrains.Annotations;
//using TeamSwim;

//namespace System.Linq
//{
//    partial class LinqExt
//    {
//        /// <summary>
//        ///     Determines if a sequence only has one element, returning the singular element if <see langword="true"/>.
//        /// </summary>
//        /// <typeparam name="T">Element type</typeparam>
//        /// <param name="source">Input sequence.</param>
//        /// <param name="single">The singular element in the source, if only one exists.</param>
//        /// <returns><see langword="true"/> if the sequence only has one element. Otherwise, <see langword="false"/>.</returns>
//        [PublicAPI]
//        [Pure]
//        public static bool IsSingle<T>(
//            [NotNull, InstantHandle] this IEnumerable<T> source, 
//            /*TODO: CONTRACT*/ out T single)
//        {
//            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

//            var two = source.Take(2).ToList();
//            if (two.Count == 1)
//            {
//                single = two.Single();
//                return true;
//            }
//            else
//            {
//                single = default;
//                return false;
//            }
//        }
//    }
//}
