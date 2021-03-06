﻿using JetBrains.Annotations;

namespace System
{
    public static partial class Int32Ext
    {
        /// <summary>
        ///     Converts the string representation of a number to its nullable 32-bit signed integer equivalent. 
        ///     A return value indicates whether the conversion succeeded.
        /// <para>
        ///     A <see langword="null"/> value will return <see langword="true" />.
        /// </para>
        /// </summary>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in s, if the conversion succeeded, or null if the conversion failed. The conversion fails if the s parameter is null or System.String.Empty, is not of the correct format, or represents a number less than System.Int32.MinValue or greater than System.Int32.MaxValue. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if s was converted successfully; otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool TryParseNullable([CanBeNull] string value, [CanBeNull] out int? result)
        {
            if (value == null)
            {
                result = null;
                return true;
            }

            if (Int32.TryParse(value, out var tmp))
            {
                result = tmp;
                return true;
            }
            
            result = null;
            return false;
        }
    }
}
