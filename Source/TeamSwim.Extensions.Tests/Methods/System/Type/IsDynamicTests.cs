using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemType.Tests

{
    [TestClass]
    public sealed class IsDynamicTests : BaseUnitTest
    {
        internal const string IsDynamicTest = "Type.IsDynamic()";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Type_Parameter_Throws_Exception()
        {
            Type t = null;
            var result = t.IsDynamic();

            Assert.Fail();
        }

        [TestMethod]
        public void Concrete_Interface_Returns_False()
        {
            var t = typeof(IConcrete);
            var result = t.IsDynamic();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Concrete_Type_Returns_False()
        {
            var t = typeof(ConcreteType);
            var result = t.IsDynamic();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Anonymous_Type_Returns_False()
        {
            var n = new {Prop1 = "", Prop2 = 2};
            var t = n.GetType();
            var result = t.IsDynamic();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Dynamic_Type_Returns_True()
        {
            var t = typeof(DynamicObject);
            var result = t.IsDynamic();

            Assert.IsTrue(result);
        }
        
        private class ConcreteType
        {
            
        }

        private interface IConcrete
        {
            
        }

        private class DynamicObject : IDynamicMetaObjectProvider
        {
            public DynamicMetaObject GetMetaObject(Expression parameter) => new DynamicMetaObject(null, null);
        }
    }
}
