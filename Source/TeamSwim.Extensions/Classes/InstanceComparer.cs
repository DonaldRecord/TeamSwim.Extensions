using JetBrains.Annotations;
using System.Linq.Expressions;
using TeamSwim;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Facade class for creating instances of <see cref="InstanceComparer{T}"/>.
    /// </summary>
    public static class InstanceComparer
    {
        /// <summary>
        ///     Create an instance of <see cref="InstanceComparer{T}"/> for type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type to create comparer for.</typeparam>
        /// <returns>New instance of <see cref="InstanceComparer{T}"/>.</returns>
        [PublicAPI]
        [NotNull, Pure]
        public static InstanceComparer<T> For<T>() => new InstanceComparer<T>();
    }

    /// <summary>
    ///     Creates an <see cref="IEqualityComparer{T}"/> dynamically using a
    ///     combination of properties, fields, and custom expressions.
    /// </summary>
    /// <typeparam name="T">Type of instance</typeparam>
    public class InstanceComparer<T> : IEqualityComparer<T>
    {
        private readonly Dictionary<Func<IEqualityComparer, T, T, bool>, IEqualityComparer> _equalsMethods = new Dictionary<Func<IEqualityComparer, T, T, bool>, IEqualityComparer>();
        private readonly Dictionary<Func<IEqualityComparer, T, int>, IEqualityComparer> _hashCodeMethods = new Dictionary<Func<IEqualityComparer, T, int>, IEqualityComparer>();
        private readonly HashSet<string> _debugNames = new HashSet<string>(StringComparer.Ordinal);

        /// <summary>
        ///     Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true" /> if the objects are equal. Otherwise, <see langword="false" />.</returns>
        /// <exception cref="Exception">An equality comparison callback throws an exception.</exception>
        [Pure]
        public virtual bool Equals(T x, T y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;

            foreach (var kvp in _equalsMethods)
            {
                var comparer = kvp.Value;
                var method = kvp.Key;

                var result = method.Invoke(comparer, x, y);
                if (!result)
                    return false;
            }

            return true;
        }

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <param name="obj">Object to return hash code for.</param>
        /// <returns>Hash code as <see cref="T:System.Int32" />.</returns>
        /// <exception cref="T:System.Exception">A delegate callback throws an exception.</exception>
        [Pure]
        public virtual int GetHashCode([CanBeNull] T obj)
        {
            unchecked
            {
                var result = 0;
                const int multiplier = 397;

                if (obj != null)
                {
                    foreach (var kvp in _hashCodeMethods)
                    {
                        var comparer = kvp.Value;
                        var method = kvp.Key;

                        result = (result * multiplier) ^ method.Invoke(comparer, obj);
                    }
                }

                return result;
            }
        }

        // TODO: Add "all properties" method

        /// <summary>
        ///     Fluently adds a property member to the instance comparison, with the specified comparer.
        ///     The property must have a get accessor.
        /// </summary>
        /// <typeparam name="TProperty">Property type.</typeparam>
        /// <param name="property">Expression to represent property on object.</param>
        /// <param name="comparer">Equality Comparer of type <typeparamref name="TProperty"/> to use in comparisons.</param>
        /// <returns>Same <see cref="InstanceComparer{T}"/> instance.</returns>
        [NotNull]
        public virtual InstanceComparer<T> AddProperty<TProperty>(
            [NotNull] Expression<Func<T, TProperty>> property,
            [CanBeNull] IEqualityComparer<TProperty> comparer = null)
        {
            if (property == null)
                throw Exceptions.ArgumentNull(nameof(property));

            var propertyInfo = property.GetPropertyInfo();
            var comparerProxy = new ObjectComparerProxy<TProperty>(comparer);
            var hashMethod = CompileHashCodeExpression(t => Expression.Property(t, propertyInfo));
            var equalsMethod = CompileEqualsExpression(t => Expression.Property(t, propertyInfo));

            _hashCodeMethods.Add(hashMethod, comparerProxy);
            _equalsMethods.Add(equalsMethod, comparerProxy);
            _debugNames.Add(propertyInfo.Name);

            return this;
        }

        /// <summary>
        ///     Fluently adds a field member to the instance comparison, with the specified comparer.
        /// </summary>
        /// <typeparam name="TField">Field type.</typeparam>
        /// <param name="field">Expression to represent field on object.</param>
        /// <param name="comparer">Equality Comparer of type <typeparamref name="TField"/> to use in comparisons.</param>
        /// <returns>Same <see cref="InstanceComparer{T}"/> instance.</returns>
        public virtual InstanceComparer<T> AddField<TField>(
            [NotNull] Expression<Func<T, TField>> field,
            [CanBeNull] IEqualityComparer<TField> comparer = null)
        {
            if (field == null)
                throw Exceptions.ArgumentNull(nameof(field));

            var comparerProxy = new ObjectComparerProxy<TField>(comparer);
            var fieldInfo = field.GetFieldInfo();
            var hashMethod = CompileHashCodeExpression(t => Expression.Field(t, fieldInfo));
            var equalsMethod = CompileEqualsExpression(t => Expression.Field(t, fieldInfo));

            _hashCodeMethods.Add(hashMethod, comparerProxy);
            _equalsMethods.Add(equalsMethod, comparerProxy);
            _debugNames.Add(fieldInfo.Name);

            return this;
        }

        /// <summary>
        ///     Add a custom comparison delegate to the instance comparison.
        ///     No error prevention is done internally to the expression.
        /// </summary>
        /// <typeparam name="TValue">Result type of the delegate.</typeparam>
        /// <param name="expression">Expression representing the delegate.</param>
        /// <param name="comparer">Equality Comparer of type <typeparamref name="TValue"/> for the delegate results.</param>
        /// <returns>Same <see cref="InstanceComparer{T}"/> instance.</returns>
        public virtual InstanceComparer<T> AddExpression<TValue>(
            [NotNull] Expression<Func<T, TValue>> expression,
            [CanBeNull] IEqualityComparer<TValue> comparer = null)
        {
            if (expression == null)
                throw Exceptions.ArgumentNull(nameof(expression));

            var comparerProxy = new ObjectComparerProxy<TValue>(comparer);
            var hashMethod = CompileHashCodeExpression(t => new ParameterReplacer(t).Visit(expression.Body));
            var equalsMethod = CompileEqualsExpression(t => new ParameterReplacer(t).Visit(expression.Body));

            _hashCodeMethods.Add(hashMethod, comparerProxy);
            _equalsMethods.Add(equalsMethod, comparerProxy);
            _debugNames.Add(expression.ToString());

            return this;
        }
        
        private static Func<IEqualityComparer, T, T, bool> CompileEqualsExpression(
            Func<ParameterExpression, Expression> getExpression)
        {
            // (comparer, t1, t2) => comparer.Equals(t1, t2);

            var t1 = Expression.Parameter(typeof(T), "x");
            var t2 = Expression.Parameter(typeof(T), "y");
            var comparerParam = Expression.Parameter(typeof(IEqualityComparer), "comparer");
            var expr1 = getExpression.Invoke(t1);
            var expr2 = getExpression.Invoke(t2);

            Expression<Func<IEqualityComparer, T, T, bool>> method =
                Expression.Lambda<Func<IEqualityComparer, T, T, bool>>(
                    Expression.Call(
                        comparerParam,
                        // ReSharper disable once AssignNullToNotNullAttribute
                        typeof(IEqualityComparer).GetMethod(nameof(IEqualityComparer.Equals)),
                        Expression.Convert(expr1, typeof(object)),
                        Expression.Convert(expr2, typeof(object))
                    ),
                    comparerParam, t1, t2);

            var finalMethod = method.Compile();
            return finalMethod;
        }

        private static Func<IEqualityComparer, T, int> CompileHashCodeExpression(
            Func<ParameterExpression, Expression> getMemberExpr)
        {
            //(comparer, t) => comparer.GetHashCode(t.Member);

            var t = Expression.Parameter(typeof(T), "x");
            var comparerParam = Expression.Parameter(typeof(IEqualityComparer), "comparer");
            var expr = getMemberExpr.Invoke(t);

            var method = Expression.Lambda<Func<IEqualityComparer, T, int>>(
                    Expression.Call(
                        comparerParam,
                        typeof(IEqualityComparer).GetMethod(nameof(IEqualityComparer.GetHashCode)),
                        Expression.Convert(expr, typeof(object))),
                    comparerParam, t);

            var finalMethod = method.Compile();
            return finalMethod;
        }

        //class used to bridge gap from IEqualityComparer<T> to IEqualityComparer
        internal class ObjectComparerProxy<T2> : IEqualityComparer
        {
            private readonly IEqualityComparer<T2> _genericComparer;

            public ObjectComparerProxy([CanBeNull] IEqualityComparer<T2> comparer)
            {
                _genericComparer = comparer ?? EqualityComparer<T2>.Default;
            }

            public int GetHashCode(object obj)
            {
                var t = (T2) obj;
                var result = 0;
                if (t != null)
                    result = _genericComparer.GetHashCode(t);
                return result;
            }

            bool IEqualityComparer.Equals(object x, object y)
            {
                var tx = (T2) x;
                var ty = (T2) y;
                return _genericComparer.Equals(tx, ty);
            }
        }

        internal class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _parameter;

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return base.VisitParameter(_parameter);
            }

            internal ParameterReplacer(ParameterExpression parameter)
            {
                _parameter = parameter;
            }
        }
    }
}
