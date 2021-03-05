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
        ///     (Opinionated)
        ///     Project a result from a sequence based on the number of elements in the sequence (none, one, or many).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="source">Sequence of elements to project result for.</param>
        /// <param name="noneConstant">Value returned when no elements are present in sequence.</param>
        /// <param name="oneConstant">Value returned when one element is present in sequence.</param>
        /// <param name="manyConstant">Value returned when more than one element is present in sequence.</param>
        /// <returns>Result of the returned constant.</returns>
        [PublicAPI]
        [MustUseReturnValue]
        public static TResult SelectConstantByCount<T, TResult>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [CanBeNull] TResult noneConstant = default,
            [CanBeNull] TResult oneConstant = default,
            [CanBeNull] TResult manyConstant = default)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            var list = source.ToList();
            if (!list.Any())
                return noneConstant;

            if (list.Count == 1)
                return oneConstant;

            return manyConstant;
        }
    }
}
