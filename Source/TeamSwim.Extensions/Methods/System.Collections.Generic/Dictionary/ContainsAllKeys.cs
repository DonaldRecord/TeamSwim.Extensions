using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using JetBrains.Annotations;

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
            if (dictionary == null) throw new NullReferenceException();
            if (keys == null) throw new ArgumentNullException();
            return keys.All(dictionary.ContainsKey);
        }

        [PublicAPI]
        [Pure]
        public static bool ContainsAllKeys<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dictionary, 
            [NotNull] params TKey[] keys) => dictionary.ContainsAllKeys(keys.ToList());
    }
}
