using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace System
{
    public static partial class StringExt
    {
        /// <summary>
        ///     Determines if a string is equal to any specified <paramref name="strings"/> using a <see cref="StringComparison"/>.
        /// </summary>
        /// <param name="stringA"></param>
        /// <param name="stringComparison"></param>
        /// <param name="strings"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static bool EqualsAny(
            [NotNull] this string stringA,
            StringComparison stringComparison,
            [CanBeNull, ItemCanBeNull, InstantHandle] IEnumerable<string> strings)
        {
            if (strings == null) return false;

            foreach (var str in strings)
            {
                if (stringA.Equals(str, stringComparison))
                    return true;
            }

            return false;
        }

        /// <summary>
        ///     Determines if a string is equal to any specified <paramref name="strings"/> using a <see cref="StringComparison"/>.
        /// </summary>
        /// <param name="stringA"></param>
        /// <param name="stringComparison"></param>
        /// <param name="strings"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static bool EqualsAny(
            [NotNull] this string stringA,
            StringComparison stringComparison,
            [ItemCanBeNull, CanBeNull] params string[] strings) => stringA.EqualsAny(stringComparison, strings.AsEnumerable());
    }
}
