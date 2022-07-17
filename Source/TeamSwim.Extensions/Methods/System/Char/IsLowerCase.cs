using JetBrains.Annotations;

namespace System
{
    partial class CharExt
    {
        /// <summary>
        ///     Determines if the specified <paramref name="value"/> is lower case.
        ///     Returns <see langword="false"/> for any non-letter characters.
        /// </summary>
        /// <param name="value">Character to check case.</param>
        /// <returns><see langword="true"/> if the specified <paramref name="value"/> is lower case. Otherwise, see <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool IsLowerCase(this char value)
        {
            if (!Char.IsLetter(value))
                return false;

            var result = Char.ToLower(value) == value;
            return result;
        }
    }
}
