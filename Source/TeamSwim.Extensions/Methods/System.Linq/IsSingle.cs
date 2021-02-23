using System.Collections.Generic;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Determines if a source collection only has one element.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <returns><see langword="true"/> if the collection only has one element. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool IsSingle<T>([NotNull, InstantHandle] this IEnumerable<T> source)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            var count = source.Count();
            return count == 1;
        }
    }
}
