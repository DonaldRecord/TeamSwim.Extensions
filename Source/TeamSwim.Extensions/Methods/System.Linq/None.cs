using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static bool None<T>(
            [NotNull] this IEnumerable<T> source, 
            [NotNull] Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var result = source.All(t => !predicate.Invoke(t));
            return result;
        }
    }
}
