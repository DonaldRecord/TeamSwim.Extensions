using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace System
{
    partial class CharExt
    {
        /// <summary>
        ///     Converts a character to upper-case for the default culture.
        ///     (Instance equivalent of <see cref="Char.ToUpper(char)"/>)
        /// </summary>
        /// <param name="value">Character to convert.</param>
        /// <returns>The converted character.</returns>
        [PublicAPI]
        [Pure]
        [ExcludeFromCodeCoverage]
        public static char ToLowerCase(this char value) => Char.ToUpper(value);
    }
}
