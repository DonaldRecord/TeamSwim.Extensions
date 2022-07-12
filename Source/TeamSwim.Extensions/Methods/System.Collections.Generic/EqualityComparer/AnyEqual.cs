using System.Linq;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Collections.Generic
{
    partial class EqualityComparerExt
    {
        /// <summary>
        ///     Determines if any elements in the <paramref name="source"/> sequence are equal to the
        ///     specified <paramref name="value"/> using the specified <paramref name="comparer"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comparer"></param>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [PublicAPI]
        [Pure]
        public static bool AnyEqual<T>(
            [NotNull] this IEqualityComparer<T> comparer, 
            [NotNull, InstantHandle] IEnumerable<T> source, 
            T value)
        {
            if (comparer == null) throw Exceptions.ArgumentNull(nameof(comparer));
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            var result = source.Any(elem => comparer.Equals(elem, value));
            return result;
        }
    }
}
