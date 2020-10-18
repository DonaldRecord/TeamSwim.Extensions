using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq.Expressions
{
    partial class ExpressionExt
    {
        /// <summary>
        ///     Determine if an <paramref name="expression"/> represents a property, and return the <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="PropertyInfo"/> instance.</param>
        /// <param name="propertyInfo"></param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="PropertyInfo"/>.</exception>
        /// <returns><see langword="true"/> if the expression represents an instance of <see cref="PropertyInfo"/>. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure, ContractAnnotation("=>true,propertyInfo:notnull;=>false,propertyInfo:null")]
        public static bool TryGetPropertyInfo<T, TProperty>(
            [CanBeNull] this Expression<Func<T, TProperty>> expression, 
            out PropertyInfo propertyInfo)
        {
            if (expression.TryGetMemberInfo(out var memberInfo))
            {
                propertyInfo = memberInfo as PropertyInfo;
                return propertyInfo != null;
            }
            else
            {
                propertyInfo = null;
                return false;
            }
        }

        /// <summary>
        ///     Determine if an <paramref name="expression"/> represents a property, and return the <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="PropertyInfo"/> instance.</param>
        /// <param name="propertyInfo"></param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="PropertyInfo"/>.</exception>
        /// <returns><see langword="true"/> if the expression represents an instance of <see cref="PropertyInfo"/>. Otherwise, <see langword="false"/>.</returns>
        [Pure, ContractAnnotation("=>true,propertyInfo:notnull;=>false,propertyInfo:null")]
        public static bool TryGetPropertyInfo<T>(
            [CanBeNull] this Expression<Func<T, object>> expression, 
            out PropertyInfo propertyInfo)
        {
            if (expression.TryGetMemberInfo(out var memberInfo))
            {
                propertyInfo = memberInfo as PropertyInfo;
                return propertyInfo != null;
            }
            else
            {
                propertyInfo = null;
                return false;
            }
        }
    }
}