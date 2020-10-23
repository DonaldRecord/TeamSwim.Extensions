using JetBrains.Annotations;

namespace System
{
    partial class BooleanExt
    {
        /// <summary>
        ///     Returns string representation of bool: "yes" for <see langword="true"/>, "no" for <see langword="false"/>.
        /// </summary>
        /// <param name="bool"><see cref="bool"/> to return string for.</param>
        /// <param name="options">Options for the format of the return string.</param>
        /// <returns>"yes" for <see langword="true"/>, "no" for <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure, NotNull]
        public static string ToYesNo(this bool @bool, ToYesNoOptions options = ToYesNoOptions.Lowercase)
        {
            switch (options)
            {
                case ToYesNoOptions.Lowercase:
                    return @bool ? "yes" : "no";
                case ToYesNoOptions.Uppercase:
                    return @bool ? "YES" : "NO";
                case ToYesNoOptions.Capital:
                    return @bool ? "Yes" : "No";
                default:
                    throw new ArgumentOutOfRangeException(nameof(options), options, null);
            }
        }
    }
}
