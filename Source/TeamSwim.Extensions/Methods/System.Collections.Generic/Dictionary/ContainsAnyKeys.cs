using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Collections.Generic
{
    partial class DictionaryExt
    {
        /// <summary>
        ///     Determines if a dictionary contains any of the specified keys.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="dictionary">Dictionary to search</param>
        /// <param name="keys">Keys to search for</param>
        /// <returns><see langword="true"/> if the dictionary contains any of the keys. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool ContainsAnyKeys<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            IEnumerable<TKey> keys)
        {
            if (dictionary == null) throw Exceptions.NullRef();
            if (keys == null) throw Exceptions.ArgumentNull(nameof(keys));
            return keys.Any(dictionary.ContainsKey);
        }

        /// <summary>
        ///     Determines if a dictionary contains any of the specified keys.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="dictionary">Dictionary to search</param>
        /// <param name="keys">Keys to search for</param>
        /// <returns><see langword="true"/> if the dictionary contains any of the keys. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure]
        public static bool ContainsAnyKeys<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dictionary,
            [NotNull] params TKey[] keys) => dictionary.ContainsAnyKeys(keys.ToList());
    }
}
