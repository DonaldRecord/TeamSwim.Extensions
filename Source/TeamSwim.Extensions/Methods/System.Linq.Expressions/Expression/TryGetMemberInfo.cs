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
        ///     Determine if an <paramref name="expression"/> represents a member, and return the <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="MemberInfo"/> instance.</param>
        /// <param name="memberInfo"></param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="MemberInfo"/>.</exception>
        /// <returns><see langword="true"/> if the expression represents an instance of <see cref="MemberInfo"/>. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure, ContractAnnotation("=> true, memberInfo: notnull; => false, memberInfo: null")]
        public static bool TryGetMemberInfo<T, TField>(this Expression<Func<T, TField>> expression, out MemberInfo memberInfo)
        {
            memberInfo = null;
            if (expression == null)
                return false;

            if (expression.Body is UnaryExpression body)
            {
                if (body.Operand is MemberExpression tmp)
                    memberInfo = tmp.Member;
            }
            else if (expression.Body is MemberExpression tmp)
            {
                memberInfo = tmp.Member;
            }

            return memberInfo != null;
        }

        /// <summary>
        ///     Determine if an <paramref name="expression"/> represents a member, and return the <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="MemberInfo"/> instance.</param>
        /// <param name="memberInfo"></param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="MemberInfo"/>.</exception>
        /// <returns><see langword="true"/> if the expression represents an instance of <see cref="MemberInfo"/>. Otherwise, <see langword="false"/>.</returns>
        [PublicAPI]
        [Pure, ContractAnnotation("=> true, memberInfo: notnull; => false, memberInfo: null")]
        public static bool TryGetMemberInfo<T>(this Expression<Func<T, object>> expression, out MemberInfo memberInfo)
        {
            memberInfo = null;
            if (expression == null)
                return false;

            if (expression.Body is UnaryExpression body)
            {
                if (body.Operand is MemberExpression tmp)
                    memberInfo = tmp.Member;
            }
            else if (expression.Body is MemberExpression tmp)
            {
                memberInfo = tmp.Member;
            }

            return memberInfo != null;
        }
    }
}