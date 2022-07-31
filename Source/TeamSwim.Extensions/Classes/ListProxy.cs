using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade for building custom <see cref="IList{T}"/> types.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    [PublicAPI]
    [DebuggerDisplay("{ProxyReference}")]
    [ExcludeFromCodeCoverage]
    public abstract class ListProxy<T> : IList<T>
    {
        /// <summary>
        ///     The underlying referenced collection that is being proxied.
        /// <para>
        ///     Do not reference a calculated collection, or any collection that cannot actually be written to.
        ///     Otherwise, errors and unexpected behaviour will occur
        ///     when calling methods such as <see cref="Add(T)"/> or <see cref="Clear"/>.
        /// </para>
        ///     If that is your intent, use <see cref="ReadOnlyCollectionProxy{T}"/> or <see cref="ReadOnlyListProxy{T}"/>.
        /// </summary>
        protected abstract IList<T> ProxyReference { get; }

        /// <inheritdoc />
        public virtual IEnumerator<T> GetEnumerator() => ProxyReference.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)ProxyReference).GetEnumerator();

        /// <inheritdoc />
        public virtual void Add(T item) => ProxyReference.Add(item);

        /// <inheritdoc />
        public virtual void Clear() => ProxyReference.Clear();

        /// <inheritdoc />
        public virtual bool Contains(T item) => ProxyReference.Contains(item);

        /// <inheritdoc />
        public virtual void CopyTo(T[] array, int arrayIndex) => ProxyReference.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public virtual bool Remove(T item) => ProxyReference.Remove(item);

        /// <inheritdoc />
        public virtual int Count => ProxyReference.Count;

        /// <inheritdoc />
        public virtual bool IsReadOnly => ProxyReference.IsReadOnly;

        /// <inheritdoc />
        public virtual int IndexOf(T item) => ProxyReference.IndexOf(item);

        /// <inheritdoc />
        public virtual void Insert(int index, T item) => ProxyReference.Insert(index, item);

        /// <inheritdoc />
        public virtual void RemoveAt(int index) => ProxyReference.RemoveAt(index);
        
        /// <inheritdoc />
        public virtual T this[int index]
        {
            get => ProxyReference[index];
            set => ProxyReference[index] = value;
        }
    }
}