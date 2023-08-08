using JetBrains.Annotations;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Return a string's value if it is not <see langword="null"/> or white space.
        ///     Otherwise, return a <paramref name="default"/>.
        ///     If you want whitespace only values not to coalesce to default,
        ///     use <paramref name="replaceWhiteSpaceString"/> parameter.
        /// </summary>
        /// <param name="value">String to check/return value for.</param>
        /// <param name="default">Default value to coalesce to when string is null/empty/whitespace.</param>
        /// <param name="replaceWhiteSpaceString">When <see langword="true"/>, </param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, ContractAnnotation("default:null=>null;default:notnull=>notnull")]
        public static string GetValueOrDefault(
            [CanBeNull] this string value, 
            string @default, 
            bool replaceWhiteSpaceString = true)
        {
            var replace = replaceWhiteSpaceString
                ? String.IsNullOrWhiteSpace(value)
                : String.IsNullOrEmpty(value);

            var result = replace ? @default : value;
            return result;
        }
    }
}