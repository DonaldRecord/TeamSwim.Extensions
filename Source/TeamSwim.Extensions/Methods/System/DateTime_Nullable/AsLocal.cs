using JetBrains.Annotations;

namespace System
{
    partial class DateTimeExt
    {
        /// <summary>
        ///     Sets the DateTime.<see cref="DateTime.Kind"/> to <see cref="DateTimeKind.Local"/> and returns.
        ///     If the <paramref name="value"/> is <see langword="null"/>, this will return <see langword="null"/>.
        /// </summary>
        /// <param name="value">DateTime value to set kind on.</param>
        /// <returns><paramref name="value"/> with Kind set to <see cref="DateTimeKind.Local"/>.</returns>
        [PublicAPI]
        // TODO: ContractAnnotation
        [MustUseReturnValue]
        public static DateTime? AsLocal(this DateTime? value)
        {
            if (value.HasValue)
                return value.Value.AsLocal();
            else
                return value;
        }
    }
}