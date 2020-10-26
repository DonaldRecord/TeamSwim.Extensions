using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Collections.Generic
{
    partial class DictionaryExt
    {
        [PublicAPI]
        [Pure]
        public static bool ContainsAllKeys<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dictionary, 
            [NotNull, InstantHandle] IEnumerable<TKey> keys)
        {
            if (dictionary == null) throw Exceptions.NullRef();
            if (keys == null) throw Exceptions.ArgumentNull(nameof(keys));
            return keys.All(dictionary.ContainsKey);
        }

        [PublicAPI]
        [Pure]
        public static bool ContainsAllKeys<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dictionary, 
            [NotNull] params TKey[] keys) => dictionary.ContainsAllKeys(keys.ToList());
    }
}
