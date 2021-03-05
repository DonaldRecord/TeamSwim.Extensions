using JetBrains.Annotations;
using TeamSwim;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Returns a substring starting at the beginning of the original string until the end of the first specified occurrence.
        ///     If the substring is not found in the source string, <see langword="null"/> is returned.
        /// <para>
        ///     Zero-length <paramref name="occurrence"/> argument will always return <see langword="null"/>.
        /// </para>
        /// </summary>
        /// <param name="value">String to return substring from.</param>
        /// <param name="occurrence">Where to end the substring.</param>
        /// <param name="stringComparison">String Comparison to use when finding the occurrence.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, CanBeNull]
        public static string SubstringAfterFirstOccurrence(
            [NotNull] this string value,
            [NotNull] string occurrence,
            StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            if (value == null) throw Exceptions.NullRef();
            if (occurrence == null) throw Exceptions.ArgumentNull(nameof(occurrence));
            if (occurrence.Length == 0)
                return null;

            var indexOf = value.IndexOf(occurrence, stringComparison);
            if (indexOf == -1)
                return null;

            var start = indexOf + occurrence.Length;
            var end = value.Length - start;
            var result = value.Substring(start, end);
            return result;
        }
    }
}