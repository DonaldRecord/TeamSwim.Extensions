using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade that can be used to eliminate <see cref="IEqualityComparer{T}"/> boilerplate code
    ///     for using a proxy <see cref="InstanceComparerProxy{T}"/> to do instance comparisons.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [PublicAPI]
    public abstract class InstanceComparerProxy<T> : IEqualityComparer<T>
    {
        /// <summary>
        ///     Instance of comparer to use in equality comparisons.
        /// </summary>
        [NotNull]
        protected abstract InstanceComparer<T> ComparerProxy { get; }

        /// <summary>
        ///     Determines if two instances of <typeparamref name="T"/> are equal to each other.
        /// </summary>
        /// <param name="x">Instance of <typeparamref name="T"/> to compare.</param>
        /// <param name="y">Instance of <typeparamref name="T"/> to compare.</param>
        /// <returns><see langword="true"/> if the two instances are equal. Otherwise, <see langword="false"/>.</returns>
        public bool Equals(T x, T y) => ComparerProxy.Equals(x, y);

        /// <summary>
        ///     Get the hash code for an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">Instance of <typeparamref name="T"/> to calculate hashcode for.</param>
        /// <returns>Hashcode of <paramref name="obj"/>.</returns>
        public int GetHashCode(T obj) => ComparerProxy.GetHashCode(obj);
    }
}