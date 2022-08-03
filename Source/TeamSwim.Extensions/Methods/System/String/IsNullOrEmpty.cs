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
        [ContractAnnotation("null=>true;notnull=>false;true=>value:null;false=>value:notnull")]
        public static bool IsNullOrEmpty(
            this string value) => 
            String.IsNullOrEmpty(value);
    }
}
