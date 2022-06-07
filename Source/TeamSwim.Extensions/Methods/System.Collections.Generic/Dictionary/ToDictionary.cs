using JetBrains.Annotations;
using System.Linq;

namespace System.Collections.Generic
{
    partial class DictionaryExt
    {
        /// <summary>
        ///     Creates a <see cref="Dictionary{TKey, TValue}"/> from an existing <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Element type</typeparam>
        /// <param name="value">Existing <see cref="IDictionary{TKey, TValue}"/> instance.</param>
        /// <returns><paramref name="value"/> as <see cref="Dictionary{TKey, TValue}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull]
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IDictionary<TKey, TValue> value)
        {
            if (value == null) 
                throw new ArgumentNullException(nameof(value));

            return value.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
