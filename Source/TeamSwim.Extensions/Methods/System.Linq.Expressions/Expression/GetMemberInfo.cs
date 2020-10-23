using System.Reflection;
using JetBrains.Annotations;

namespace System.Linq.Expressions
{
    partial class ExpressionExt
    {
        /// <summary>
        ///     Get <see cref="MemberInfo"/> from an <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="MemberInfo"/> instance.</param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="MemberInfo"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="expression"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static MemberInfo GetMemberInfo<T, TMember>([NotNull] this Expression<Func<T, TMember>> expression)
        {
            if (expression == null) throw new NullReferenceException();
            if (expression.TryGetMemberInfo(out var memberInfo))
                return memberInfo;

            throw new ArgumentException("The passed expression does not represent a member.");
        }

        /// <summary>
        ///     Get <see cref="MemberInfo"/> from an <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> containing the reference to a <see cref="MemberInfo"/> instance.</param>
        /// <exception cref="ArgumentException">Expression is not a valid <see cref="MemberExpression"/> that can return an instance of <see cref="MemberInfo"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="expression"/> is <see langword="null"/>.</exception>
        [PublicAPI]
        [Pure, NotNull]
        public static MemberInfo GetMemberInfo<T>([NotNull] this Expression<Func<T, object>> expression)
        {
            if (expression == null) throw new NullReferenceException();
            if (expression.TryGetMemberInfo(out var memberInfo))
                return memberInfo;

            throw new ArgumentException("The passed expression does not represent a member.");
        }
    }
}