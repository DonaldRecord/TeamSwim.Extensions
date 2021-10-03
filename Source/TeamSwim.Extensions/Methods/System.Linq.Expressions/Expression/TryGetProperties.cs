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
        ///  TODO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        [PublicAPI]
        public static bool TryGetProperties<T>(this Expression<Func<T, object>> expr, out ICollection<PropertyInfo> properties)
        {
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

        private class MemberAccessExpansionVisitor : ExpressionVisitor
        {
            private readonly MemberTypes _memberTypes;
            private readonly List<MemberInfo> _members = new List<MemberInfo>();
            private bool _valid = true;
            
            public IReadOnlyCollection<MemberInfo> Members => _members;

            public MemberAccessExpansionVisitor(MemberTypes memberTypes)
            {
                _memberTypes = memberTypes;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                if (_valid && _memberTypes.HasFlag(node.Member.MemberType))
                {
                    _members.Add(node.Member);
                }
                else
                {
                    _valid = false;
                    _members.Clear();
                }

                return base.VisitMember(node);
            }
        }
    }
}
