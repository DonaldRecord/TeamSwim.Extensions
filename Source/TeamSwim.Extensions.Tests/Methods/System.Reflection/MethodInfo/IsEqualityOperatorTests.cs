//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace System.Reflection
//{
//    [TestClass]
//    public class IsEqualityOperatorTests
//    {
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void Null_Throws_Exception()
//        {
//            MethodInfo uut = null;
//            var actual = uut.IsEqualityOperator();
//            Assert.Fail();
//        }

//        [TestMethod]
//        public void Equals_Method_Does_Not_Return_True()
//        {
//            var scope = new Scope().TestWithExpression(e => e.Prop1 == e.Prop2);
//            Assert.IsFalse(scope.IsEqualityOperator);
//        }

//        [TestMethod]
//        public void Operator_Returns_True()
//        {
//            //var scope = new Scope().TestWithExpression(e => e.Prop1 == e.Prop2);
//            //Assert.IsTrue(scope.IsEqualityOperator);
//            var methods = typeof(Entity)
//                //.GetMethods(BindingFlags.Static | BindingFlags.CreateInstance | BindingFlags.Public)
//                .GetMethods(B)
//                .ToList();
//            Assert.IsNotNull(methods);
            
//            //var method = typeof(Entity).GetMethod("op_Equality", );
//            //Assert.IsNotNull(method);

//            //var actual = method.IsEqualityOperator();
//            //Assert.IsTrue(actual);
//        }

//        [TestMethod]
//        public void Separate_Method_Returns_False()
//        {

//        }

//        [TestMethod]
//        public void Separate_Special_Name_Method_Returns_False()
//        {

//        }

//        class Scope : ExpressionVisitor
//        {
//            private int _methodCallCount;
//            public bool IsEqualityOperator { get; private set; }

//            protected override Expression VisitMethodCall(MethodCallExpression node)
//            {
//                _methodCallCount++;

//                if (_methodCallCount > 1)
//                    throw new AssertInconclusiveException();

//                var methodInfo = node.Method;
//                IsEqualityOperator = methodInfo.IsEqualityOperator();

//                return base.VisitMethodCall(node);
//            }

//            public Scope TestWithExpression(Expression<Func<Entity, bool>> expr)
//            {
//                Visit(expr.Body);
//                return this;
//            }
//        }

//        class Entity
//        {
//            public int Prop1 { get; set; }
//            public int Prop2 { get; set; }
//        }
//    }
//}
