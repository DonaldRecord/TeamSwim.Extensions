using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Call <see cref="String.Join(char, object?[])"/> on a sequence of strings
        ///     via an extension method invocation.
        /// </summary>
        /// <param name="source">Sequence of strings to join.</param>
        /// <param name="separator">Separator character.</param>
        /// <returns>Joined string.</returns>
        public static string StringJoin(this IEnumerable<string> source, char separator)
        {
            var result = String.Join(separator.ToString(), source);
            return result;
        }

        /// <summary>
        ///     Call <see cref="String.Join(string, object?[])"/> on a sequence of strings
        ///     via an extension method invocation.
        /// </summary>
        /// <param name="source">Sequence of strings to join.</param>
        /// <param name="separator">Separator character.</param>
        /// <returns>Joined string.</returns>
        public static string StringJoin(this IEnumerable<string> source, string separator)
        {
            var result = String.Join(separator, source);
            return result;
        }
    }
}
