using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Linq.Expressions
{
    partial class ExpressionExt
    {
        /// <summary>
        ///     Attempts to get the members (properties/fields) referenced in a LambdaExpression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        [PublicAPI]
        // TODO: Contract annotations
        public static bool TryGetMembers<T>(
            [NotNull] this Expression<Func<T, object>> expr,
            out ICollection<MemberInfo> members)
        {
            if (expr == null)
                throw Exceptions.ArgumentNull(nameof(expr));

            members = new List<MemberInfo>();
            var visitor = new MemberAccessExpansionVisitor(MemberTypes.Property | MemberTypes.Field);
            visitor.Visit(expr);

            foreach (var member in visitor.Members)
            {
                members.Add(member);
            }

            return members.Any();
        }
    }
}
