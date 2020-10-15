using JetBrains.Annotations;

namespace System
{
    public static partial class DayOfWeekExt
    {
        /// <summary>
        ///     Determines if the specified <see cref="DayOfWeek"/> is a weekend day.
        /// </summary>
        /// <param name="value">The <see cref="DayOfWeek"/> to determine.</param>
        /// <returns><see langword="true"/> if the day of week is <see cref="DayOfWeek.Monday"/>, <see cref="DayOfWeek.Tuesday"/>, <see cref="DayOfWeek.Wednesday"/>, <see cref="DayOfWeek.Thursday"/> or <see cref="DayOfWeek.Friday"/>. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool IsWeekend(this DayOfWeek value)
        {
            switch (value)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday:
                    return true;
                default:
                    return false;
            }
        }
    }
}