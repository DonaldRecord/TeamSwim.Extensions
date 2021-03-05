using System.Linq;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Collections.Generic
{
    partial class DictionaryExt
    {
        /// <summary>
        ///     Try getting one of the specified entries from the dictionary.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="dict">Dictionary to search within</param>
        /// <param name="key">Found key</param>
        /// <param name="value">Found value</param>
        /// <param name="keys">Keys to search for.</param>
        /// <returns><see langword="true"/> if one of the keys is found. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        public static bool TryGetCoalesce<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dict,
            out TKey key,
            out TValue value,
            params TKey[] keys)
        {
            if (dict == null) throw Exceptions.NullRef();
            foreach (var k in keys)
            {
                if (dict.ContainsKey(k))
                {
                    key = k;
                    value = dict[k];
                    return true;
                }
            }

            key = default;
            value = default;
            return false;
        }

        /// <summary>
        ///     Try getting one of the specified entries from the dictionary.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="dict">Dictionary to search within</param>
        /// <param name="value">Found value</param>
        /// <param name="keys">Keys to search for.</param>
        /// <returns><see langword="true"/> if one of the keys is found. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        public static bool TryGetCoalesce<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dict,
            out TValue value,
            params TKey[] keys)
        {
            return TryGetCoalesce(dict, out _, out value, keys);
        }

        /// <summary>
        ///     Try getting one of the specified entries from the dictionary.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="dict">Dictionary to search within</param>
        /// <param name="key">Found key</param>
        /// <param name="value">Found value</param>
        /// <param name="keys">Keys to search for.</param>
        /// <returns><see langword="true"/> if one of the keys is found. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        public static bool TryGetCoalesce<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dict,
            out TKey key,
            out TValue value,
            IEnumerable<TKey> keys) => dict.TryGetCoalesce(out key, out value, keys.ToArray());

        /// <summary>
        ///     Try getting one of the specified entries from the dictionary.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="dict">Dictionary to search within</param>
        /// <param name="value">Found value</param>
        /// <param name="keys">Keys to search for.</param>
        /// <returns><see langword="true"/> if one of the keys is found. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        public static bool TryGetCoalesce<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> dict,
            out TValue value,
            IEnumerable<TKey> keys) => dict.TryGetCoalesce(out _, out value, keys.ToArray());
    }
}
