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
        ///     Get the first matching entry in the dictionary based on the specified keys.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="dict">Dictionary to search for entries.</param>
        /// <param name="keys">Specified keys to search for.</param>
        /// <returns>The value of the first matching key. Otherwise, <see langword="default"/> of <typeparamref name="TValue"/>.</returns>
        [PublicAPI]
        [Pure]
        public static TValue GetCoalesce<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dict,
            params TKey[] keys)
        {
            if (dict == null) throw Exceptions.NullRef();
            foreach (var key in keys)
            {
                if (dict.ContainsKey(key))
                    return dict[key];
            }

            return default;
        }

        /// <summary>
        ///     Get the first matching entry in the dictionary based on the specified keys.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="dict">Dictionary to search for entries.</param>
        /// <param name="keys">Specified keys to search for.</param>
        /// <returns>The value of the first matching key. Otherwise, <see langword="default"/> of <typeparamref name="TValue"/>.</returns>
        [PublicAPI]
        [Pure]
        public static TValue GetCoalesce<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dict,
            [NotNull] IEnumerable<TKey> keys) => dict.GetCoalesce(keys.ToArray());
    }
}
