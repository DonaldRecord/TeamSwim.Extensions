﻿using JetBrains.Annotations;

namespace System
{
    /// <summary>
    ///     Extension method class for <see cref="int"/>.
    /// </summary>
    public static partial class Int32Ext
    {
        /// <summary>
        ///     Determines if <paramref name="value"/> is between <paramref name="start"/> and <paramref name="end"/> values.
        /// </summary>
        /// <param name="value"><see cref="int"/> value</param>
        /// <param name="start">Start value of range.</param>
        /// <param name="end">End value of range.</param>
        /// <param name="inclusive">When set to true, the <paramref name="value"/> is allowed to match the <paramref name="start"/> or <paramref name="end"/> value.</param>
        /// <returns><see langword="true"/> if the value is in the specified range. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool Between(this int value, int start, int end, bool inclusive = true)
        {
            if (inclusive)
                return (value >= start && value <= end);
            else
                return (value > start && value < end);
        }
    }
}
