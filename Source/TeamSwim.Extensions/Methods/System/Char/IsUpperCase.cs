using JetBrains.Annotations;

namespace System
{
    partial class CharExt
    {
        /// <summary>
        ///     Determines if the specified <paramref name="value"/> is upper case.
        ///     Returns <see langword="false"/> for any non-letter characters.
        /// </summary>
        /// <param name="value">Character to check case.</param>
        /// <returns><see langword="true"/> if the specified <paramref name="value"/> is upper case. Otherwise, see <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool IsUpperCase(this char value)
        {
            if (!Char.IsLetter(value))
                return false;

            var result = Char.ToUpper(value) == value;
            return result;
        }
    }
}