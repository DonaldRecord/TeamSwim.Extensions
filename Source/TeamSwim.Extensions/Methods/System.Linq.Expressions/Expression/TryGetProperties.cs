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
        ///     Attempts to get the properties referenced in a LambdaExpression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        [PublicAPI]
        public static bool TryGetProperties<T>(
            [NotNull] this Expression<Func<T, object>> expr, 
            out ICollection<PropertyInfo> properties)
        {
            if (expr == null)
                throw Exceptions.ArgumentNull(nameof(expr));

            properties = new List<PropertyInfo>();
            var visitor = new MemberAccessExpansionVisitor(MemberTypes.Property);
            visitor.Visit(expr);

            foreach (var member in visitor.Members)
            {
                if (member is PropertyInfo property)
                    properties.Add(property);
            }

            return properties.Any();
        }
    }
}
