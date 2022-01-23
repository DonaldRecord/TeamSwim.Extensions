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
        ///     Removes the specified type (<typeparamref name="T"/>) from the type sequence, if it exists.
        /// </summary>
        /// <typeparam name="T">The type to remove from the sequence.</typeparam>
        /// <param name="source">The type sequence to modify.</param>
        /// <returns>The type sequence with the specified type parameter removed from the sequence.</returns>
        public static IEnumerable<Type> Except<T>(this IEnumerable<Type> source) => source.Except(new[] { typeof(T) });
    }
}
