using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq.Expressions
{
    [TestClass]
    public class GetPropertyInfoTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Null_Typed_Argument_Throws_Exception()
        {
            Expression<Func<TestClass, string>> expr = null;
            var actual = expr.GetPropertyInfo();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Valid_Typed_Field_Throws_Exception()
        {
            Expression<Func<TestClass, string>> expr = c => c.Field;
            var actual = expr.GetPropertyInfo();
        }

        [TestMethod]
        public void Valid_Typed_Property_Throws_Exception()
        {
            Expression<Func<TestClass, string>> expr = c => c.Property;
            var actual = expr.GetPropertyInfo();
            Assert.IsInstanceOfType(actual, typeof(PropertyInfo));
            Assert.AreEqual(TestClass.PropertyInfo, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_Typed_Expression_Throws_Exception()
        {
            Expression<Func<TestClass, string>> expr = c => "constant";
            var actual = expr.GetPropertyInfo();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Null_Untyped_Argument_Throws_Exception()
        {
            Expression<Func<TestClass, object>> expr = null;
            var actual = expr.GetPropertyInfo();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Valid_Untyped_Field_Throws_Exception()
        {
            Expression<Func<TestClass, object>> expr = c => c.Field;
            var actual = expr.GetPropertyInfo();
        }

        [TestMethod]
        public void Valid_Untyped_Property_Throws_Exception()
        {
            Expression<Func<TestClass, object>> expr = c => c.Property;
            var actual = expr.GetPropertyInfo();
            Assert.IsInstanceOfType(actual, typeof(PropertyInfo));
            Assert.AreEqual(TestClass.PropertyInfo, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_Untyped_Expression_Throws_Exception()
        {
            Expression<Func<TestClass, object>> expr = c => "constant";
            var actual = expr.GetPropertyInfo();
        }

        public class TestClass
        {
            public string Field;
            public static FieldInfo FieldInfo => typeof(TestClass).GetField(nameof(Field));
            public string Property { get; set; }
            public static PropertyInfo PropertyInfo => typeof(TestClass).GetProperty(nameof(Property));
            public string Method() => null;
        }
    }
}
