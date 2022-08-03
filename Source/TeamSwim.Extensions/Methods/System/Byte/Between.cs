//using System.Linq;
//using JetBrains.Annotations;

//namespace System
//{
//    partial class ByteExt
//    {
//        /// <summary>
//        ///     Determines if <paramref name="value"/> is between <paramref name="threshold1"/>
//        ///     and <paramref name="threshold2"/> values.
//        /// <para>
//        ///     The threshold parameters will be ordered internally to figure out which one is lower and which one is higher -
//        ///     they can be passed in either order.
//        /// </para>
//        /// </summary>
//        /// <param name="value"><see cref="byte"/> value</param>
//        /// <param name="threshold1">One end of range.</param>
//        /// <param name="threshold2">Other end of range.</param>
//        /// <param name="inclusive">When set to true, the <paramref name="value"/> is allowed to match the <paramref name="threshold1"/> or <paramref name="threshold2"/> value. Default value is <see langword="true"/>.</param>
//        /// <returns><see langword="true"/> if the value is in the specified range. Otherwise, <see langword="false"/>.</returns>
//        [PublicAPI]
//        [Pure]
//        public static bool Between(this byte value, byte threshold1, byte threshold2, bool inclusive = true)
//        {
//            var list = new[] {threshold1, threshold2};
//            var start = list.Min();
//            var end = list.Max();
//            var result = BetweenImpl(value, start, end, inclusive);
//            return result;
//        }

//        private static bool BetweenImpl(byte value, byte start, byte end, bool inclusive = true)
//        {
//            if (inclusive)
//                return value >= start && value <= end;

//            return value > start && value < end;
//        }
//    }
//}
