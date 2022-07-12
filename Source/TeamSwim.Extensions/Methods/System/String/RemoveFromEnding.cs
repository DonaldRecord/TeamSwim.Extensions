using JetBrains.Annotations;
using TeamSwim;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     Remove the specified ending from a string, only if it exists within that string.
        /// </summary>
        /// <param name="value">String value to seek.</param>
        /// <param name="substring">Substring to be removed.</param>
        /// <param name="stringComparison">String comparison mode used for detection.</param>
        /// <returns>If the substring exists, will return a new string instance without the specified ending. Otherwise, <paramref name="value"/>.</returns>
        [PublicAPI]
        [Pure]
        public static string RemoveFromEnding(
            [NotNull] this string value,
            [NotNull] string substring,
            StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            if (value == null) throw Exceptions.ArgumentNull(nameof(value));
            if (substring == null) throw Exceptions.ArgumentNull(nameof(substring));

            if (value.Equals(String.Empty, stringComparison))
                return value;
            if (substring.Equals(String.Empty, stringComparison))
                return value;

            if (value.EndsWith(substring, stringComparison))
                return value.Substring(0, value.Length - substring.Length);
            else
                return value;
        }
    }
}