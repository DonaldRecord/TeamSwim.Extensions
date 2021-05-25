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
        ///     Return a random element from the sequence. Will 
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="source">Sequence to return a random element from.</param>
        /// <returns>A random element from the sequence.</returns>
        [PublicAPI]
        [Pure]
        public static T Random<T>([NotNull, InstantHandle] this IEnumerable<T> source)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            var result = source.OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
            return result;
        }
    }
}
