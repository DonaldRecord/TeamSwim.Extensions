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
        ///     Determine if an <paramref name="expression"/> represents a field, and return the <see cref="FieldInfo"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="FieldInfo"/> instance.</param>
        /// <param name="fieldInfo"></param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="FieldInfo"/>.</exception>
        /// <returns><see langword="true"/> if the expression represents an instance of <see cref="FieldInfo"/>. Otherwise, <see langword="false"/>.</returns>
        [Pure, ContractAnnotation("=>true,fieldInfo:notnull;=>false,fieldInfo: null")]
        public static bool TryGetFieldInfo<T, TField>(this Expression<Func<T, TField>> expression, out FieldInfo fieldInfo)
        {
            if (expression.TryGetMemberInfo(out var memberInfo))
            {
                fieldInfo = memberInfo as FieldInfo;
                return fieldInfo != null;
            }
            else
            {
                fieldInfo = null;
                return false;
            }
        }

        /// <summary>
        ///     Determine if an <paramref name="expression"/> represents a field, and return the <see cref="FieldInfo"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="FieldInfo"/> instance.</param>
        /// <param name="fieldInfo"></param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="FieldInfo"/>.</exception>
        /// <returns><see langword="true"/> if the expression represents an instance of <see cref="FieldInfo"/>. Otherwise, <see langword="false"/>.</returns>
        [Pure, ContractAnnotation("=>true,fieldInfo:notnull;=>false,fieldInfo: null")]
        public static bool TryGetFieldInfo<T>(this Expression<Func<T, object>> expression, out FieldInfo fieldInfo)
        {
            if (expression.TryGetMemberInfo(out var memberInfo))
            {
                fieldInfo = memberInfo as FieldInfo;
                return fieldInfo != null;
            }
            else
            {
                fieldInfo = null;
                return false;
            }
        }
    }
}