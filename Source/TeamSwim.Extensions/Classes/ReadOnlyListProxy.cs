using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade for building custom read-only list types.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    [PublicAPI]
    [DebuggerDisplay("{ProxyReference}")]
    [ExcludeFromCodeCoverage]
    public abstract class ReadOnlyListProxy<T> : IReadOnlyList<T>
    {
        /// <summary>
        ///     The underlying referenced collection that is being proxied.
        /// </summary>
        protected abstract IReadOnlyList<T> ProxyReference { get; }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator() => ProxyReference.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)ProxyReference).GetEnumerator();

        /// <inheritdoc />
        public int Count => ProxyReference.Count;

        /// <inheritdoc />
        public T this[int index] => ProxyReference[index];
    }
}