using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq
{
    partial class LinqExt
    {
        [PublicAPI]
        [Pure]
        public static bool IsSingle<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source, 
            /*TODO: CONTRACT*/ out T single)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));

            var two = source.Take(2).ToList();
            if (two.Count == 1)
            {
                single = two.Single();
                return true;
            }
            else
            {
                single = default;
                return false;
            }
        }
    }
}
