using JetBrains.Annotations;

namespace System
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     Determines if the specified <see cref="DateTime"/> falls on a Monday, Tuesday, Wednesday, Thursday, or Friday (weekday).
        /// </summary>
        /// <param name="dateTime">DateTime to check for weekday.</param>
        /// <returns><see langword="true"/> if the DateTime falls on a weekday. Otherwise, <see langword="false"/>.</returns>
        [Pure, PublicAPI]
        public static bool IsWeekday(this DateTime dateTime)
        {
            var day = dateTime.DayOfWeek;

            switch (day)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return false;
                default:
                    return true;
            }
        }
    }
}
