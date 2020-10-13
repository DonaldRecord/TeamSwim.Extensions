using JetBrains.Annotations;

namespace System
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     Returns the converted <see cref="DateTimeOffset"/>? from the <see cref="DateTime"/>?.
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/>? being converted to <see cref="DateTimeOffset"/>?.</param>
        /// <param name="dateTimeKind">Specified kind of time to be turned into a <see cref="DateTimeOffset"/></param>
        /// <returns>A DateTimeOffset object based on the specifed DateTime.</returns>
        [Pure, PublicAPI, ContractAnnotation("dateTime:null => null")]
        public static DateTimeOffset? Offset(
            [CanBeNull] this DateTime? dateTime,
            DateTimeKind dateTimeKind = DateTimeKind.Unspecified)
        {
            if (!dateTime.HasValue)
                return null;

            DateTimeOffset utcTime = DateTime.SpecifyKind(dateTime.Value, dateTimeKind);
            return utcTime;
        }
    }
}

