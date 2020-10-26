using System.Reflection;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq.Expressions
{
    partial class ExpressionExt
    {
        /// <summary>
        ///     Get <see cref="PropertyInfo"/> from an <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="PropertyInfo"/> instance.</param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="PropertyInfo"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="expression"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static PropertyInfo GetPropertyInfo<T, TProperty>([NotNull] this Expression<Func<T, TProperty>> expression)
        {
            if (expression == null) throw Exceptions.NullRef();
            if (expression.TryGetPropertyInfo(out var propertyInfo))
                return propertyInfo;
            else
                throw new ArgumentException("The passed expression does not represent a property.");
        }

        /// <summary>
        ///     Get <see cref="PropertyInfo"/> from an <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="PropertyInfo"/> instance.</param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="PropertyInfo"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="expression"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static PropertyInfo GetPropertyInfo<T>(this Expression<Func<T, object>> expression)
        {
            if (expression == null) throw Exceptions.NullRef();
            if (expression.TryGetPropertyInfo(out var propertyInfo))
                return propertyInfo;
            else
                throw new ArgumentException("The passed expression does not represent a property.");
        }
    }
}