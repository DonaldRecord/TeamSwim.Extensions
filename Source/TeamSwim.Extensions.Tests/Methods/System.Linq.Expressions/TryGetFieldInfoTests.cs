using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq.Expressions
{
    [TestClass]
    public class TryGetFieldInfoTests
    {
        [TestMethod]
        public void Valid_Typed_Field_Expressions_Return_Expected_Values()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass, string>(c => c.Field, out var member);
            Assert.IsTrue(actual);
            Assert.AreEqual(TestClass.FieldInfo, member);
        }

        [TestMethod]
        public void Valid_Typed_Unary_Field_Expressions_Return_Expected_Values()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass, string>(c => (string)c.Field, out var member);
            Assert.IsTrue(actual);
            Assert.AreEqual(TestClass.FieldInfo, member);
        }

        [TestMethod]
        public void Valid_Typed_Property_Expression_Returns_False()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass, string>(c => c.Property, out var member);
            Assert.IsFalse(actual);
            Assert.IsNull(member);
        }

        [TestMethod]
        public void Invalid_Typed_Expression_Returns_False()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass, string>(c => "string", out var member);
            Assert.IsFalse(actual);
            Assert.IsNull(member);
        }

        [TestMethod]
        public void Null_Typed_Expression_Returns_False()
        {
            Expression<Func<TestClass, string>> expr = null;
            var actual = expr.TryGetFieldInfo(out var member);
            Assert.IsFalse(actual);
            Assert.IsNull(member);
        }

        [TestMethod]
        public void Method_Expression_Returns_Null()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass>(c => c.Method(), out var member);
            Assert.IsFalse(actual);
            Assert.IsNull(member);
        }

        [TestMethod]
        public void Valid_Untyped_Field_Expressions_Return_Expected_Values()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass>(c => c.Field, out var member);
            Assert.IsTrue(actual);
            Assert.AreEqual(TestClass.FieldInfo, member);
        }

        [TestMethod]
        public void Valid_Untyped_Unary_Field_Expressions_Return_Expected_Values()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass>(c => (string)c.Field, out var member);
            Assert.IsTrue(actual);
            Assert.AreEqual(TestClass.FieldInfo, member);
        }

        [TestMethod]
        public void Valid_Untyped_Property_Expressions_Returns_Null()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass>(c => c.Property, out var member);
            Assert.IsFalse(actual);
            Assert.IsNull(member);
        }

        [TestMethod]
        public void Invalid_Untyped_Expression_Returns_False()
        {
            var actual = ExpressionExt.TryGetFieldInfo<TestClass>(c => "string", out var member);
            Assert.IsFalse(actual);
            Assert.IsNull(member);
        }

        [TestMethod]
        public void Null_Untyped_Expression_Returns_False()
        {
            Expression<Func<TestClass, object>> expr = null;
            var actual = expr.TryGetFieldInfo<TestClass>(out var member);
            Assert.IsFalse(actual);
            Assert.IsNull(member);
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
