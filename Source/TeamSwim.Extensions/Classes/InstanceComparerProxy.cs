using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade that can be used to eliminate <see cref="IEqualityComparer{T}"/> boilerplate code
    ///     for using a proxy <see cref="InstanceComparerProxy{T}"/> to do instance comparisons.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class InstanceComparerProxy<T> : IEqualityComparer<T>
    {
        protected abstract InstanceComparerProxy<T> ComparerProxy { get; }

        public bool Equals(T x, T y) => ComparerProxy.Equals(x, y);
        public int GetHashCode(T obj) => ComparerProxy.GetHashCode(obj);
    }
}