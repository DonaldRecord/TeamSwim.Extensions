using System.Diagnostics;
using JetBrains.Annotations;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade for building custom collection types.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    [PublicAPI]
    [DebuggerDisplay("{ProxyReference}")]
    public abstract class CollectionProxy<T> : ICollection<T>
    {
        /// <summary>
        ///     The underlying referenced collection that is being proxied.
        /// <para>
        ///     Do not reference a calculated collection, or any collection that cannot actually be written to.
        ///     Otherwise, errors and unexpected behaviour will occur
        ///     when calling methods such as <see cref="Add(T)"/> or <see cref="Clear"/>.
        /// </para>
        ///     If that is your intent, use <see cref="ReadOnlyCollectionProxy{T}"/>.
        /// </summary>
        [NotNull]
        protected abstract ICollection<T> ProxyReference { get; }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public virtual IEnumerator<T> GetEnumerator() => ProxyReference.GetEnumerator();

        /// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public virtual void Add(T item) => ProxyReference.Add(item);

        /// <summary>Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public virtual void Clear() => ProxyReference.Clear();

        /// <summary>Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.</summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>true if <paramref name="item">item</paramref> is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.</returns>
        public virtual bool Contains(T item) => ProxyReference.Contains(item);

        /// <summary>Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.</summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array">array</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex">arrayIndex</paramref> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException">The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"></see> is greater than the available space from <paramref name="arrayIndex">arrayIndex</paramref> to the end of the destination <paramref name="array">array</paramref>.</exception>
        public virtual void CopyTo(T[] array, int arrayIndex) => ProxyReference.CopyTo(array, arrayIndex);

        /// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>true if <paramref name="item">item</paramref> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if <paramref name="item">item</paramref> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.</returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public virtual bool Remove(T item) => ProxyReference.Remove(item);

        /// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</summary>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</returns>
        public virtual int Count => ProxyReference.Count;

        /// <summary>Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</summary>
        /// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only; otherwise, false.</returns>
        public virtual bool IsReadOnly => ProxyReference.IsReadOnly;

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)ProxyReference).GetEnumerator();
    }
}
