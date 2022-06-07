using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.IO
{
    partial class StringExt
    {
        /// <summary>
        ///     Get the last path segment of a directory/file path.
        /// </summary>
        /// <param name="value">Directory/file path to get last segment from.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or whitespace.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static string GetLastPathSegment(this string value)
        {
            if (value == null)
                throw Exceptions.ArgumentNull(nameof(value));

            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Invalid null or whitespace argument value.", nameof(value));

            var result = value
                .Split(new[] { @"\" }, StringSplitOptions.RemoveEmptyEntries)
                .Last();

            return result;
        }
    }
}
