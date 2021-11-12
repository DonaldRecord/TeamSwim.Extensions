using JetBrains.Annotations;

namespace System
{
    partial class DateTimeExt
    {
        /// <summary>
        ///     Sets the DateTime.<see cref="DateTime.Kind"/> to <see cref="DateTimeKind.Utc"/> and returns.
        /// </summary>
        /// <param name="value">DateTime value to set kind on.</param>
        /// <returns><paramref name="value"/> with Kind set to <see cref="DateTimeKind.Utc"/></returns>
        [PublicAPI]
        // TODO: ContractAnnotation
        [MustUseReturnValue]
        public static DateTime? AsUtc(this DateTime? value)
        {
            if (value.HasValue)
                return value.Value.AsUtc();
            else
                return value;
        }
    }
}
