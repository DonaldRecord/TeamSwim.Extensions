using System;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade for creating custom read-only Dictionary types.
    /// </summary>
    /// <typeparam name="TKey">Dictionary key type.</typeparam>
    /// <typeparam name="TValue">Dictionary value element type.</typeparam>
    public abstract class ReadOnlyDictionaryProxy<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        /// <summary>
        ///     The underlying referenced dictionary that is being proxied.
        /// </summary>
        [NotNull]
        protected abstract IReadOnlyDictionary<TKey, TValue> ProxyReference { get; }

        /// <inheritdoc/>
        public virtual TValue this[TKey key] => ProxyReference[key];

        /// <inheritdoc/>
        public virtual IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => ProxyReference.GetEnumerator();

        /// <inheritdoc/>
        public virtual int Count => ProxyReference.Count;

        /// <inheritdoc/>
        public virtual bool ContainsKey(TKey key) => ProxyReference.ContainsKey(key);
        
        /// <inheritdoc/>
        public virtual bool TryGetValue(TKey key, out TValue value) => ProxyReference.TryGetValue(key, out value);
        
        /// <summary>
        ///     Gets an enumerable collection that contains the keys in the read-only dictionary.
        /// </summary>
        public virtual IEnumerable<TKey> Keys => ProxyReference.Keys;

        /// <summary>
        ///     Gets an enumerable collection that contains the values in the read-only dictionary.
        /// </summary>
        public virtual IEnumerable<TValue> Values => ProxyReference.Values;

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)ProxyReference).GetEnumerator();
    }
}
