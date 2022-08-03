using System.Linq;
using JetBrains.Annotations;

namespace System
{
    public static partial class ComparableExt
    {
        /// <summary>
        ///     Determines if <paramref name="value"/> is between <paramref name="threshold1"/> and <paramref name="threshold2"/> values.
        /// <para>
        ///     The threshold parameters will be ordered internally to figure out which one is lower and which one is higher -
        ///     they can be passed in either order.
        /// </para>
        ///     By default, will return <see langword="true"/> if the value equals either of the thresholds but
        ///     this can be disabled by setting <paramref name="inclusive"/> to <see langword="false" />.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <param name="threshold1">Start value of range.</param>
        /// <param name="threshold2">End value of range.</param>
        /// <param name="inclusive">When set to true, the <paramref name="value"/> is allowed to match the <paramref name="threshold1"/> or <paramref name="threshold2"/> value.</param>
        /// <returns><see langword="true"/> if the value is in the specified range. Otherwise, <see langword="false"/>. Default value is <see langword="true"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool Between<T>(this T value, T threshold1, T threshold2, bool inclusive = true) where T : IComparable<T>
        {
            var list = new[] { threshold1, threshold2 };
            var start = list.Min();
            var end = list.Max();
            var result = inclusive
                ? BetweenInclusive(value, start, end)
                : BetweenExclusive(value, start, end);

            return result;
        }

        private static bool BetweenExclusive<T>(T value, T start, T end) where T : IComparable<T>
        {
            var startCompare = value.CompareTo(start);
            if (startCompare <= 0)
                return false;

            var endCompare = value.CompareTo(end);
            if (endCompare >= 0)
                return false;

            return true;
        }

        private static bool BetweenInclusive<T>(T value, T start, T end) where T : IComparable<T>
        {
            var startCompare = value.CompareTo(start);
            if (startCompare < 0)
                return false;

            var endCompare = value.CompareTo(end);
            if (endCompare > 0)
                return false;

            return true;
        }
    }
}
