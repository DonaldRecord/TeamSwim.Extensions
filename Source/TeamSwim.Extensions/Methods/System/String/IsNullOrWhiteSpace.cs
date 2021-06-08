using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">String to test.</param>
        /// <returns><see langword="true"/> if the string is null, empty, or consists only of white-space characters. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        [ExcludeFromCodeCoverage]
        // TODO: Contract Annotation
        public static bool IsNullOrWhiteSpace(
            //[CanBeNull, NotNullWhen(false)] this string value) => TODO: FIX THIS
            [CanBeNull] this string value) =>
            String.IsNullOrWhiteSpace(value);
    }
}