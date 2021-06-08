//using System;
//using System.Collections.Generic;
//using System.Text;
//using JetBrains.Annotations;

//namespace System.Linq
//{
//    partial class LinqExt
//    {
//        /// <summary>
//        ///     Computes the average of a sequence of values that are obtained by invoking
//        ///     a transform function on each element of the input sequence.
//        /// <para>
//        ///     If the input sequence is empty, no <see cref="InvalidOperationException"/> will be thrown
//        ///     and the specified <paramref name="default"/> value will be returned.
//        /// </para>
//        /// </summary>
//        /// <typeparam name="T">Element type</typeparam>
//        /// <param name="source">Input sequence</param>
//        /// <param name="selector">Transform function to retrieve <see cref="int"/>.</param>
//        /// <param name="default">Return value when sequence is empty.</param>
//        /// <returns>Computed average of a sequence.</returns>
//        [PublicAPI]
//        [Pure]
//        public static double AverageOrDefault<T>(
//            [NotNull, InstantHandle] this IEnumerable<T> source,
//            [NotNull, InstantHandle] Func<T, int> selector,
//            double @default = default)
//        {
//            if (source == null) throw new ArgumentNullException(nameof(source));

//            var list = source.ToList();
//            if (list.Any())
//                return list.Average(selector);
//            else
//                return @default;
//        }

//        /// <summary>
//        ///     Computes the average of a sequence of <see cref="int"/>s.
//        /// <para>
//        ///     If the input sequence is empty, no <see cref="InvalidOperationException"/> will be thrown
//        ///     and the specified <paramref name="default"/> value will be returned.
//        /// </para>
//        /// </summary>
//        /// <param name="source">Input sequence</param>
//        /// <param name="default">Return value when sequence is empty.</param>
//        /// <returns>Computed average of a sequence.</returns>
//        [PublicAPI]
//        [Pure]
//        public static double AverageOrDefault(
//            [NotNull, InstantHandle] this IEnumerable<int> source,
//            int @default = default) => source.AverageOrDefault(d => d, @default);
//    }
//}
