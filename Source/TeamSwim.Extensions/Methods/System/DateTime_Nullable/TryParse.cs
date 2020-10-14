using JetBrains.Annotations;

namespace System
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     Converts the string representation of a number to its nullable <see cref="DateTime"/> equivalent.
        ///     A <see langword="null"/> value will return <see langword="true"/>.
        /// </summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the nullable DateTime value equivalent of the DateTime contained in s, if the conversion succeeded, or null if the conversion failed. The conversion fails if the s parameter is null or System.String.Empty, is not of the correct format, or represents a DateTime less than System.DateTime.MinValue or greater than System.DateTime.MaxValue. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if s was converted successfully; otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool TryParse([CanBeNull] string s, [CanBeNull] out DateTime? result)
        {
            if (s == null)
            {
                result = null;
                return true;
            }
            else
            {
                if (DateTime.TryParse(s, out var tmp))
                {
                    result = tmp;
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }
        }
    }
}
