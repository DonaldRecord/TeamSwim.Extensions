using JetBrains.Annotations;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade for building custom read-only collection types.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    [PublicAPI]
    public abstract class ReadOnlyCollectionProxy<T> : IReadOnlyCollection<T>
    {
        /// <summary>
        ///     The underlying referenced collection that is being proxied.
        /// </summary>
        [NotNull]
        protected abstract IReadOnlyCollection<T> ProxyReference { get; }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public virtual IEnumerator<T> GetEnumerator() => ProxyReference.GetEnumerator();
        
        /// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</summary>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</returns>
        public virtual int Count => ProxyReference.Count;
        
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)ProxyReference).GetEnumerator();
    }
}
