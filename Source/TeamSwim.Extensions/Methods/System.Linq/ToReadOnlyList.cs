using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace System.Linq
{
    partial class LinqExt
    {
        /// <summary>
        ///     Create a readonly list.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="source">Source to create readonly list from.</param>
        /// <returns>The new readonly list.</returns>
        [PublicAPI]
        [Pure, NotNull]
        public static IReadOnlyList<T> ToReadOnlyList<T>([NotNull, InstantHandle] IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var list = source.ToList();
            var result = new ReadOnlyCollection<T>(list);
            return result;
        }
    }
}