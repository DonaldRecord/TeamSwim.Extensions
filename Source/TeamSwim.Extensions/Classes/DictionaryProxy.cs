using System;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade for creating custom Dictionary types.
    /// </summary>
    /// <typeparam name="TKey">Dictionary key type.</typeparam>
    /// <typeparam name="TValue">Dictionary value element type.</typeparam>
    public abstract class DictionaryProxy<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        ///     The underlying referenced dictionary that is being proxied.
        /// <para>
        ///     Do not reference a calculated dictionary, or any dictionary that cannot actually be written to.
        ///     Otherwise, errors and unexpected behaviour will occur
        ///     when calling methods such as <see cref="Add(TKey, TValue)"/> or <see cref="Clear"/>.
        /// </para>
        ///     If that is your intent, use <see cref="ReadOnlyDictionaryProxy{TKey, TValue}"/>.
        /// </summary>
        protected abstract IDictionary<TKey, TValue> ProxyReference { get; }

        /// <summary>
        ///     Gets or sets the element by the specified key.
        /// </summary>
        /// <param name="key">Key of element</param>
        /// <returns>The value of the element.</returns>
        public virtual TValue this[TKey key]
        {
            get => ProxyReference[key];
            set => ProxyReference[key] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => ProxyReference.GetEnumerator();

        /// <inheritdoc/>
        public virtual void Add(KeyValuePair<TKey, TValue> item) => ProxyReference.Add(item);

        /// <inheritdoc/>
        public virtual void Clear() => ProxyReference.Clear();

        /// <inheritdoc/>
        public virtual bool Contains(KeyValuePair<TKey, TValue> item) => ProxyReference.Contains(item);

        /// <inheritdoc/>
        public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ProxyReference.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public virtual bool Remove(KeyValuePair<TKey, TValue> item) => ProxyReference.Remove(item);

        /// <inheritdoc/>
        public virtual int Count => ProxyReference.Count;

        /// <inheritdoc/>
        public virtual bool IsReadOnly => ProxyReference.IsReadOnly;

        /// <inheritdoc/>
        public virtual void Add(TKey key, TValue value) => ProxyReference.Add(key, value);

        /// <inheritdoc/>
        public virtual bool ContainsKey(TKey key) => ProxyReference.ContainsKey(key);

        /// <inheritdoc/>
        public virtual bool Remove(TKey key) => ProxyReference.Remove(key);

        /// <inheritdoc/>
        public virtual bool TryGetValue(TKey key, out TValue value) => ProxyReference.TryGetValue(key, out value);

        /// <inheritdoc/>
        public virtual ICollection<TKey> Keys => ProxyReference.Keys;

        /// <inheritdoc/>
        public virtual ICollection<TValue> Values => ProxyReference.Values;

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)ProxyReference).GetEnumerator();
    }
}
