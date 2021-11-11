using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade for building custom set types.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    public abstract class SetProxy<T> : ISet<T>
    {
        /// <summary>
        ///     The underlying referenced set that is being proxied.
        /// <para>
        ///     Do not reference a calculated set, or any set that cannot actually be written to.
        ///     Otherwise, errors and unexpected behaviour will occur
        ///     when calling methods such as Add or Clear.
        /// </para>
        /// </summary>
        //     UP ONE If that is your intent, use <see cref="ReadOnlyCollectionProxy{T}"/>.
        [NotNull]
        protected abstract ISet<T> ProxyReference { get; }

        /// <summary>
        ///     Callback for when elements are added to the set successfully.
        /// </summary>
        /// <param name="element">Element successfully added.</param>
        protected virtual void OnAddSucceeded(T element) { }

        /// <summary>
        ///     Callback for when elements are not added to the set successfully.
        /// </summary>
        /// <param name="element">Element not successfully added.</param>
        protected virtual void OnAddFailed(T element) { }

        /// <summary>
        ///     Callback for when elements are removed from the set successfully.
        /// </summary>
        /// <param name="element">Element successfully removed.</param>
        protected virtual void OnRemoveSucceeded(T element) { }

        /// <summary>
        ///     Callback for when elements are not removed from the set successfully.
        /// </summary>
        /// <param name="element">Element not successfully removed.</param>
        protected virtual void OnRemoveFailed(T element) { }

        /// <inheritdoc/>
        public virtual IEnumerator<T> GetEnumerator() => ProxyReference.GetEnumerator();
        
        /// <inheritdoc/>
        public virtual void ExceptWith(IEnumerable<T> other) => ProxyReference.ExceptWith(other);

        /// <inheritdoc/>
        public virtual void IntersectWith(IEnumerable<T> other) => ProxyReference.IntersectWith(other);

        /// <inheritdoc/>
        public virtual bool IsProperSubsetOf(IEnumerable<T> other) => ProxyReference.IsProperSubsetOf(other);

        /// <inheritdoc/>
        public virtual bool IsProperSupersetOf(IEnumerable<T> other) => ProxyReference.IsProperSupersetOf(other);

        /// <inheritdoc/>
        public virtual bool IsSubsetOf(IEnumerable<T> other) => ProxyReference.IsSubsetOf(other);

        /// <inheritdoc/>
        public virtual bool IsSupersetOf(IEnumerable<T> other) => ProxyReference.IsSupersetOf(other);

        /// <inheritdoc/>
        public virtual bool Overlaps(IEnumerable<T> other) => ProxyReference.Overlaps(other);

        /// <inheritdoc/>
        public virtual bool SetEquals(IEnumerable<T> other) => ProxyReference.SetEquals(other);

        /// <inheritdoc/>
        public virtual void SymmetricExceptWith(IEnumerable<T> other) => ProxyReference.SymmetricExceptWith(other);

        /// <inheritdoc/>
        public virtual void UnionWith(IEnumerable<T> other) => ProxyReference.UnionWith(other);
        
        /// <inheritdoc/>
        public virtual void Clear() => ProxyReference.Clear();

        /// <inheritdoc/>
        public virtual bool Contains(T item) => ProxyReference.Contains(item);

        /// <inheritdoc/>
        public virtual void CopyTo(T[] array, int arrayIndex) => ProxyReference.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public virtual int Count => ProxyReference.Count;

        /// <inheritdoc/>
        public virtual bool IsReadOnly => ProxyReference.IsReadOnly;
        
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc/>
        public virtual bool Remove(T item)
        {
            var result = ProxyReference.Remove(item);
            if (result)
                OnRemoveSucceeded(item);
            else
                OnRemoveFailed(item);
            return result;
        }

        /// <inheritdoc/>
        void ICollection<T>.Add(T item)
        {
            var addSucceeded = ProxyReference.Add(item);
            if (addSucceeded)
                OnAddSucceeded(item);
            else
                OnAddFailed(item);
        }

        /// <inheritdoc/>
        bool ISet<T>.Add(T item)
        {
            var result = ProxyReference.Add(item);
            if (result)
                OnAddSucceeded(item);
            else
                OnAddFailed(item);
            return result;
        }
    }
}
