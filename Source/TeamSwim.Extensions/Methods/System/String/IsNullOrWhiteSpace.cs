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
        [ContractAnnotation("null=>true;notnull=>false;true=>value:null;false=>value:notnull")]
        public static bool IsNullOrWhiteSpace(
            [NotNullWhen(false)] this string value) =>
            String.IsNullOrWhiteSpace(value);
    }
}