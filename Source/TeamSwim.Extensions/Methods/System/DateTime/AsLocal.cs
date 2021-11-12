using JetBrains.Annotations;

namespace System
{
    partial class DateTimeExt
    {
        /// <summary>
        ///     Sets the DateTime.<see cref="DateTime.Kind"/> to <see cref="DateTimeKind.Local"/> and returns.
        /// </summary>
        /// <param name="value">DateTime value to set kind on.</param>
        /// <returns><paramref name="value"/> with Kind set to <see cref="DateTimeKind.Local"/></returns>
        [PublicAPI]
        [MustUseReturnValue]
        public static DateTime AsLocal(this DateTime value)
        {
            if (value.Kind != DateTimeKind.Local)
                return DateTime.SpecifyKind(value, DateTimeKind.Local);
            else
                return value;
        }
    }
}