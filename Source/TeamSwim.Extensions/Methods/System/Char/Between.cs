using JetBrains.Annotations;

namespace System
{
    /// <summary>
    ///     Extension method class for <see cref="char"/>.
    /// </summary>
    public static partial class CharExt
    {
        /// <summary>
        ///     Determines if <paramref name="value"/> is between <paramref name="start"/> and <paramref name="end"/> values.
        /// </summary>
        /// <param name="value"><see cref="char"/> value</param>
        /// <param name="start">Start value of range.</param>
        /// <param name="end">End value of range.</param>
        /// <param name="inclusive">When set to true, the <paramref name="value"/> is allowed to match the <paramref name="start"/> or <paramref name="end"/> value.</param>
        /// <returns><see langword="true"/> if the value is in the specified range. Otherwise, <see langword="false"/>.</returns>
        [Pure, PublicAPI]
        public static bool Between(this char value, char start, char end, bool inclusive)
        {
            if (inclusive)
                return value >= start && value <= end;

            return value > start && value < end;
        }

        /// <summary>
        ///     Determines if <paramref name="value"/> is between <paramref name="start"/> and <paramref name="end"/> values.
        /// </summary>
        /// <param name="value"><see cref="char"/> value</param>
        /// <param name="start">Start value of range.</param>
        /// <param name="end">End value of range.</param>
        /// <returns><see langword="true"/> if the value is in the specified range. Otherwise, <see langword="false"/>.</returns>
        [Pure, PublicAPI]
        public static bool Between(this char value, char start, char end) => Between(value, start, end, true);
    }
}
