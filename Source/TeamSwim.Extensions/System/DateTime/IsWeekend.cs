using JetBrains.Annotations;

namespace System
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     Determines if the specified <see cref="DateTime"/> falls on a Saturday or Sunday (weekend).
        /// </summary>
        /// <param name="dateTime">DateTime to check for weekend.</param>
        /// <returns><see langword="true"/> if the DateTime falls on a weekend day. Otherwise, <see langword="false"/>.</returns>
        [Pure, PublicAPI]
        public static bool IsWeekend(this DateTime dateTime)
        {
            var day = dateTime.DayOfWeek;

            switch (day)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return true;
                default:
                    return false;
            }
        }
    }
}
