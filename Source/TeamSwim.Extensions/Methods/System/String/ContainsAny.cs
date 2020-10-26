using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using TeamSwim;

// using System.Linq;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     Determines if any of the values are contained within the string.
        /// </summary>
        /// <param name="value">String to check for values.</param>
        /// <param name="checks">Values to check for in string.</param>
        /// <returns><see langword="true"/> if any of the values are contained in the string. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> or <paramref name="checks"/> is <see langword="null" />.</exception>
        [PublicAPI]
        [Pure]
        public static bool ContainsAny(
            [NotNull] this string value, 
            [NotNull, ItemCanBeNull] params string[] checks)
        {
            if (value == null) throw Exceptions.ArgumentNull(nameof(value));
            if (checks == null) throw Exceptions.ArgumentNull(nameof(checks));

            return checks.Any(value.Contains);
        }

        /// <summary>
        ///     Determines if any of the values are contained within the string.
        /// </summary>
        /// <param name="value">String to check for values.</param>
        /// <param name="comparison">String Comparison to use for checking values.</param>
        /// <param name="checks">Values to check for in string.</param>
        /// <returns><see langword="true"/> if any of the values are contained in the string. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        [PublicAPI]
        [Pure]
        public static bool ContainsAny(
            [NotNull] this string value,
            StringComparison comparison,
            [NotNull, ItemNotNull] params string[] checks)
        {
            if (value == null) throw Exceptions.ArgumentNull(nameof(value));
            return checks.Any(str => Contains(value, str, comparison));
        }

        internal static bool Contains(string @string, string value, StringComparison comparison)
            => @string.IndexOf(value, comparison) >= 0;

        /// <summary>
        ///     Determines if any of the values are contained within the string.
        /// </summary>
        /// <param name="value">String to check for values.</param>
        /// <param name="checks">Values to check for in string.</param>
        /// <returns><see langword="true"/> if any of the values are contained in the string. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        [PublicAPI]
        [Pure]
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
        [PublicAPI]
        [Pure]
        public static bool ContainsAny(
            [NotNull] this string value, 
            StringComparison comparison, 
            [NotNull, ItemCanBeNull, InstantHandle] IEnumerable<string> checks) => ContainsAny(value, comparison, checks.ToArray());
    }
}