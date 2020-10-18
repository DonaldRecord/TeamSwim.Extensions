//using System;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;

//namespace System.Collections.Generic
//{
//    public class InstanceComparer<T> : IEqualityComparer<T>
//    {
//        private HashSet<Func<T, T, bool>> _equalDelegates = new HashSet<Func<T, T, bool>>();
//        private HashSet<Func<T, int>> _hashCodeDelegates = new HashSet<Func<T, int>>();

//        public bool Equals(T x, T y)
//        {
//            foreach (var del in _equalDelegates)
//            {
//                var equals = del.Invoke(x, y);
//                if (!equals)
//                    return false;
//            }

//            return true;
//        }

//        public int GetHashCode(T obj)
//        {
//            throw new NotImplementedException();
//        }

//        public InstanceComparer<T> AddProperty(PropertyInfo property) => this;
//        public InstanceComparer<T> AddProperty(Expression<Func<T, object>> property) => this;
//        public InstanceComparer<T> AddField(FieldInfo field) => this;
//        public InstanceComparer<T> AddField(Expression<Func<T, object>> field) => this;
//        public InstanceComparer<T> AddMember(MemberInfo member) => this;
//        public InstanceComparer<T> AddExpression<TValue>(Func<T, TValue> expression, IEqualityComparer<TValue> comparer = null) => this;

//    }
//}
