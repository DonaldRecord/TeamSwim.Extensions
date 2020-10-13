using JetBrains.Annotations;

namespace System
{
    public static partial class StringExt
    {
        /// <summary>
        ///     Version of <see cref="String.Equals(string, string, StringComparison)"/> that is safe with <see langword="null"/> strings.
        /// </summary>
        /// <param name="strA"><see cref="string"/> A to be compared.</param>
        /// <param name="strB"><see cref="string"/> B to be compared.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns></returns>
        [Pure, PublicAPI]
        public static bool NullEquals(
            [CanBeNull] this string strA,
            [CanBeNull] string strB,
            StringComparison comparisonType)
        {
            if (strA == null)
                return strB == null;
            else
                return strB != null && String.Equals(strA, strB, comparisonType);
        }
    }
}
