﻿using System.Reflection;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq.Expressions
{
    partial class ExpressionExt
    {
        /// <summary>
        ///     Get <see cref="FieldInfo"/> from an <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="FieldInfo"/> instance.</param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="FieldInfo"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="expression"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static FieldInfo GetFieldInfo<T, TField>([NotNull] this Expression<Func<T, TField>> expression)
        {
            if (expression == null) throw Exceptions.NullRef();
            if (expression.TryGetFieldInfo(out var fieldInfo))
                return fieldInfo;
                
            throw new ArgumentException("The passed expression does not represent a field.");
        }

        /// <summary>
        ///     Get <see cref="FieldInfo"/> from an <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="FieldInfo"/> instance.</param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="FieldInfo"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="expression"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static FieldInfo GetFieldInfo<T>([NotNull] this Expression<Func<T, object>> expression)
        {
            if (expression == null) throw Exceptions.NullRef();
            if (expression.TryGetFieldInfo(out var fieldInfo))
                return fieldInfo;
                
            throw new ArgumentException("The passed expression does not represent a field.");
        }
    }
}