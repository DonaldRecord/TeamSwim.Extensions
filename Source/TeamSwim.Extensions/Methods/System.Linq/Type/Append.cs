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
        ///     Appends a <see cref="Type"/> to the end of the sequence using a type parameter.
        /// </summary>
        /// <typeparam name="T">Type to append to sequence.</typeparam>
        /// <param name="source">Sequence to be appended.</param>
        /// <returns>The appended sequence.</returns>
        [PublicAPI]
        [Pure, NotNull, LinqTunnel]
        public static IEnumerable<Type> Append<T>([NotNull] this IEnumerable<Type> source)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            return source.Append(typeof(T));
        }
    }
}
