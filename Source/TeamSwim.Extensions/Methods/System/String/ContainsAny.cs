using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static partial class StringExt
    {
        /// <summary>
        ///     Determines if any of the values are contained within the string.
        /// </summary>
        /// <param name="value">String to check for values.</param>
        /// <param name="checks">Values to check for in string.</param>
        /// <returns><see langword="true"/> if any of the values are contained in the string. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> or <paramref name="checks"/> is <see langword="null" />.</exception>
        [Pure, PublicAPI]
        public static bool ContainsAny(
            [NotNull] this string value, 
            [NotNull, ItemCanBeNull] params string[] checks)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (checks == null) throw new ArgumentNullException(nameof(checks));

            return checks.Any(value.Contains);
        }

        ///// <summary>
        /////     Determines if any of the values are contained within the string.
        ///// </summary>
        ///// <param name="value">String to check for values.</param>
        ///// <param name="comparison">String Comparison to use for checking values.</param>
        ///// <param name="checks">Values to check for in string.</param>
        ///// <returns><see langword="true"/> if any of the values are contained in the string. Otherwise, <see langword="false"/>.</returns>
        ///// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        //[Pure, PublicAPI]
        //public static bool ContainsAny(
        //    [NotNull] this string value, 
        //    StringComparison comparison,
        //    [NotNull, ItemNotNull] params string[] checks)
        //{
        //    if (value == null) throw new ArgumentNullException(nameof(value));

        //    return checks.Any(str => value.Contains(str, comparison)); //TODO: <----WTF
        //}

        /// <summary>
        ///     Determines if any of the values are contained within the string.
        /// </summary>
        /// <param name="value">String to check for values.</param>
        /// <param name="checks">Values to check for in string.</param>
        /// <returns><see langword="true"/> if any of the values are contained in the string. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        [Pure, PublicAPI, Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static bool ContainsAny(
            [NotNull] this string value, 
            [NotNull, ItemCanBeNull, InstantHandle] IEnumerable<string> checks) => ContainsAny(value, checks.ToArray());

        /// <summary>
        ///     Determines if any of the values are contained within the string.
        /// </summary>
        /// <param name="value">String to check for values.</param>
        /// <param name="comparison">String Comparison to use for checking values.</param>
        /// <param name="checks">Values to check for in string.</param>
        /// <returns><see langword="true"/> if any of the values are contained in the string. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        [Pure, PublicAPI, Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static bool ContainsAny(
            [NotNull] this string value, 
            StringComparison comparison, 
            [NotNull, ItemCanBeNull, InstantHandle] IEnumerable<string> checks) => ContainsAny(value, comparison, checks.ToArray());
    }
}