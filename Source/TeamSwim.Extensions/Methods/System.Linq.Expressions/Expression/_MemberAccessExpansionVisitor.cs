using System.Collections.Generic;
using System.Reflection;

namespace System.Linq.Expressions
{
    internal class MemberAccessExpansionVisitor : ExpressionVisitor
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
