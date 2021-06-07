using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Input sequence whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns><see langword="true"/> any elements in the source sequence pass the test in the specified predicate; otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool Any<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source, 
            [NotNull, InstantHandle] Func<T, int, bool> predicate)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (predicate == null) throw Exceptions.ArgumentNull(nameof(predicate));
            
            var i = 0;
            foreach (var item in source)
            {
                var result = predicate.Invoke(item, i);
                if (result)
                    return true;

                i++;
            }

            return false;
        }
    }
}
