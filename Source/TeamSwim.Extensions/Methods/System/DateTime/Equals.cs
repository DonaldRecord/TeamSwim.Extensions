using JetBrains.Annotations;

namespace System
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     Returns a value indicating that two DateTimes are equal, or are within a certain (absolute) <see cref="TimeSpan"/> of each other.
        /// </summary>
        /// <param name="dateTimeA">First <see cref="DateTime"/> of comparison.</param>
        /// <param name="dateTimeB">Second <see cref="DateTime"/> of comparison.</param>
        /// <param name="delta">Delta <see cref="TimeSpan"/> period.</param>
        /// <param name="inclusive">Value indicating the difference between the two <see cref="DateTime"/>s will return <see langword="true"/> if equal to the <paramref name="delta"/> <see cref="TimeSpan"/>. Default value is <see langword="true"/>.</param>
        /// <exception cref="OverflowException">The different between <paramref name="dateTimeA"/> &amp; <paramref name="dateTimeB"/> is <see cref="F:System.TimeSpan.MinValue" />. </exception>
        [PublicAPI]
        [Pure]
        public static bool Equals(this DateTime dateTimeA, DateTime dateTimeB, TimeSpan delta, bool inclusive = true)
        {
            var diff = (dateTimeA - dateTimeB).Duration();
            if (inclusive)
                return diff <= delta;
            else
                return diff < delta;
        }
    }
}
