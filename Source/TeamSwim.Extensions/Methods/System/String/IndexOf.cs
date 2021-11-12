using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     Returns the index of the first occurrence of a character that returns <see langword="true"/>
        ///     to the provided <paramref name="predicate"/>.
        ///     If no character matches the the provided <paramref name="predicate"/>, -1 is returned.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="predicate">The predicate to evaluate the string's characters.</param>
        /// <returns>The first index where <paramref name="predicate"/> returns <see langword="true"/>. Otherwise, -1.</returns>
        [PublicAPI]
        [Pure]
        public static int IndexOf(
            [NotNull] this string value,
            [NotNull] Func<char, bool> predicate)
        {
            if (value == null)
                throw Exceptions.ArgumentNull(nameof(value));
            if (predicate == null)
                throw Exceptions.ArgumentNull(nameof(predicate));

            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];
                if (predicate.Invoke(c))
                    return i;
            }

            return -1;
        }
    }
}
