using JetBrains.Annotations;

namespace System
{
    partial class Int64Ext
    {
        /// <summary>
        ///     Determines if <paramref name="value"/> is between <paramref name="start"/> and <paramref name="end"/> values.
        /// </summary>
        /// <param name="value"><see cref="Int64"/> value</param>
        /// <param name="start">Start value of range.</param>
        /// <param name="end">End value of range.</param>
        /// <param name="inclusive">When set to true, the <paramref name="value"/> is allowed to match the <paramref name="start"/> or <paramref name="end"/> value. Default value is <see langword="true"/>.</param>
        /// <returns><see langword="true"/> if the value is in the specified range. Otherwise, <see langword="false"/>.</returns>
        [Pure, PublicAPI]
        public static bool Between(this long value, long start, long end, bool inclusive = true)
        {
            if (inclusive)
                return value >= start && value <= end;

            return value > start && value < end;
        }
    }
}
