using System.Linq;
using JetBrains.Annotations;

namespace System
{
    partial class Int16Ext
    {
        /// <summary>
        ///     Determines if <paramref name="value"/> is between <paramref name="threshold1"/> and <paramref name="threshold2"/> values.
        /// </summary>
        /// <para>
        ///     The threshold parameters will be ordered internally to figure out which one is lower and which one is higher -
        ///     they can be passed in either order.
        /// </para>
        /// <param name="value"><see cref="short"/> value</param>
        /// <param name="threshold1">Start value of range.</param>
        /// <param name="threshold2">End value of range.</param>
        /// <param name="inclusive">When set to true, the <paramref name="value"/> is allowed to match the <paramref name="threshold1"/> or <paramref name="threshold2"/> value.</param>
        /// <returns><see langword="true"/> if the value is in the specified range. Otherwise, <see langword="false"/>. Default value is <see langword="true"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool Between(this short value, short threshold1, short threshold2, bool inclusive = true)
        {
            var list = new[] {threshold1, threshold2};
            var start = list.Min();
            var end = list.Max();
            var result = BetweenImpl(value, start, end, inclusive);
            return result;
        }

        private static bool BetweenImpl(short value, short start, short end, bool inclusive = true)
        {
            if (inclusive)
                return value >= start && value <= end;

            return value > start && value < end;
        }
    }
}
