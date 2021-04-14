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
        public static bool Any<T>(
            [NotNull, InstantHandle] this IEnumerable<T> source, 
            [NotNull, InstantHandle] Func<T, int, bool> predicate)
        {
            if (source == null) throw Exceptions.ArgumentNull(nameof(source));
            if (predicate == null) throw Exceptions.ArgumentNull(nameof(predicate));
            
            var i = 0;
            foreach (var item in source)
            {
                var result = predicate.Invoke(item, i);
                if (result)
                    return true;

                i++;
            }

            return false;
        }
    }
}
