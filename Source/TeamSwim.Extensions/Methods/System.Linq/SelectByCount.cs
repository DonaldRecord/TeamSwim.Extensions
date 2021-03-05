using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

// ReSharper disable ConvertToNullCoalescingCompoundAssignment

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
        /// <param name="none">Transform function called when no elements are present in sequence.</param>
        /// <param name="one">Transform function called when one element is present in sequence.</param>
        /// <param name="many">Transform function called when more than one element is present in sequence.</param>
        /// <returns>Result of the called transform function.</returns>
        [PublicAPI]
        [MustUseReturnValue]
        public static TResult SelectByCount<T, TResult>(
            [NotNull, InstantHandle] this IEnumerable<T> source,
            [CanBeNull, InstantHandle] Func<TResult> none = null,
            [CanBeNull, InstantHandle] Func<T, TResult> one = null,
            [CanBeNull, InstantHandle] Func<ICollection<T>, TResult> many = null)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            none = none ?? (() => default);
            one = one ?? (_ => default);
            many = many ?? (_ => default);

            var list = source.ToList();
            if (!list.Any())
                return none.Invoke();
            
            if (list.Count == 1)
                return one.Invoke(list.Single());
            
            return many.Invoke(list);
        }
    }
}