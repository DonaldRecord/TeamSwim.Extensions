using JetBrains.Annotations;

namespace System
{
    /// <summary>
    ///     Extension method class for <see cref="DayOfWeek"/>.
    /// </summary>
    public static partial class DayOfWeekExt
    {
        /// <summary>
        ///     Determines if the specified <see cref="DayOfWeek"/> is a weekday.
        /// </summary>
        /// <param name="value">The <see cref="DayOfWeek"/> to determine.</param>
        /// <returns><see langword="true"/> if the day of week is <see cref="DayOfWeek.Saturday"/> or <see cref="DayOfWeek.Sunday"/>. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool IsWeekday(this DayOfWeek value)
        {
            switch (value)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday:
                    return false;
                default:
                    return true;
            }
        }
    }
}
