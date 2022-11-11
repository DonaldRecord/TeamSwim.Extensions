using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Collections.Generic
{
    /// <summary>
    ///     <see cref="IEqualityComparer{T}"/> that will solely use an object's type for equality comparison with other objects.
    /// </summary>
    /// <typeparam name="T">Type constraint of objects to compare.</typeparam>
    public class TypeComparer<T> : IEqualityComparer<T>
    {
        /// <inheritdoc/>
        public bool Equals(T x, T y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;

            var result = TypeComparer.Default.Equals(x.GetType(), y.GetType());
            return result;
        }

        /// <inheritdoc/>
        public int GetHashCode(T obj) => TypeComparer.Default.GetHashCode(obj?.GetType());
    }
}

namespace System.Collections
{
    /// <summary>
    ///     <see cref="IEqualityComparer{T}"/> that will solely use an object's type for equality comparison with other objects.
    /// </summary>
    public class TypeComparer : IEqualityComparer
    {
        /// <summary>
        ///     Common re-usable instance of <see cref="TypeComparer"/>.
        /// </summary>
        [PublicAPI]
        public static TypeComparer Default { [PublicAPI] get; } = new TypeComparer();

        /// <inheritdoc/>
        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;

            var result = EqualityComparer<Type>.Default.Equals(x.GetType(), y.GetType());
            return result;
        }

        /// <inheritdoc/>
        public int GetHashCode(object obj) => obj == null 
            ? 0 
            : EqualityComparer<Type>.Default.GetHashCode(obj.GetType());

        /// <summary>
        ///     Create an instance of <see cref="TypeComparer{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type constraint of objects to compare.</typeparam>
        /// <returns>New instance of <see cref="TypeComparer{T}"/>.</returns>
        [PublicAPI]
        public static TypeComparer<T> For<T>() => new TypeComparer<T>();
    }
}
