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
        [PublicAPI]
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