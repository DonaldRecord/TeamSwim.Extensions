using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System
{
    partial class StringExt
    {
        /// <summary>
        ///     (Opinionated)
        ///     Create sequence of substrings from a string, splitting elements from the capital letters.
        /// </summary>
        /// <param name="value">String to split.</param>
        /// <returns>Sequence of strings, each starting with a capital letter.</returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<string> SplitByCapitalLettersEnumerable(this string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            var sb = new StringBuilder();

            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];
                var shouldReturn = Char.IsUpper(c) && i != 0;
                if (shouldReturn)
                {
                    var result = sb.ToString();
                    yield return result;
                    sb.Clear();
                }

                sb.Append(c);
            }

            var final = sb.ToString();
            yield return final;
        }
    }
}
