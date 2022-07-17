using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     Indicates whether the specified string is null or an empty string ("").
        /// </summary>
        /// <param name="value">String to test.</param>
        /// <returns><see langword="true"/> if the string is null or empty. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        [ExcludeFromCodeCoverage]
        // TODO: Contract Annotation
        public static bool IsNullOrEmpty(
            [CanBeNull] this string value) => 
            String.IsNullOrEmpty(value);
    }
}
