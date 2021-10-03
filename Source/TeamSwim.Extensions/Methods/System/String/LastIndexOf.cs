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
        ///     
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static int LastIndexOf(
            [NotNull] this string value, 
            [NotNull] Func<char, bool> predicate)
        {
            if (value == null)
                throw Exceptions.ArgumentNull(nameof(value));
            if (predicate == null)
                throw Exceptions.ArgumentNull(nameof(predicate));

            for (var i = value.Length - 1; i >= 0; i--)
            {
                var c = value[i];
                if (predicate.Invoke(c))
                    return i;
            }

            return -1;
        }
    }
}
