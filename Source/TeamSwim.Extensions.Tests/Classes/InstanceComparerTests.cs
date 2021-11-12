using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Classes
{
    [TestClass]
    public class InstanceComparerTests
    {
        [TestMethod]
        public void Valid_Property_Expression_Returns_Expected_Results()
        {
            var comparer = InstanceComparer.For<TestClass>()
                .AddProperty(x => x.StringProperty, StringComparer.OrdinalIgnoreCase);

            var a = new TestClass { StringProperty = "a" };
            var b = new TestClass { StringProperty = "A" };
            var c = new TestClass { StringProperty = "b" };

            Assert.IsTrue(comparer.Equals(a, a));
            Assert.IsTrue(comparer.Equals(b, b));
            Assert.IsTrue(comparer.Equals(a, b));
            Assert.IsFalse(comparer.Equals(a, null));
            Assert.IsFalse(comparer.Equals(b, null));
            Assert.IsFalse(comparer.Equals(c, null));
            Assert.IsFalse(comparer.Equals(a, c));
            Assert.IsFalse(comparer.Equals(b, c));

            Assert.AreEqual(comparer.GetHashCode(a), comparer.GetHashCode(b));
            Assert.AreNotEqual(comparer.GetHashCode(a), comparer.GetHashCode(c));
            Assert.AreNotEqual(comparer.GetHashCode(b), comparer.GetHashCode(c));
        }

        [TestMethod]
        public void Valid_Field_Expression_Returns_Expected_Results()
        {
            var comparer = InstanceComparer.For<TestClass>()
                .AddField(x => x.StringField, StringComparer.OrdinalIgnoreCase);

            var a = new TestClass { StringField = "a" };
            var b = new TestClass { StringField = "A" };
            var c = new TestClass { StringField = "b" };

            Assert.IsTrue(comparer.Equals(a, a));
            Assert.IsTrue(comparer.Equals(b, b));
            Assert.IsTrue(comparer.Equals(a, b));
            Assert.IsFalse(comparer.Equals(a, null));
            Assert.IsFalse(comparer.Equals(b, null));
            Assert.IsFalse(comparer.Equals(c, null));
            Assert.IsFalse(comparer.Equals(a, c));
            Assert.IsFalse(comparer.Equals(b, c));

            Assert.AreEqual(comparer.GetHashCode(a), comparer.GetHashCode(b));
            Assert.AreNotEqual(comparer.GetHashCode(a), comparer.GetHashCode(c));
            Assert.AreNotEqual(comparer.GetHashCode(b), comparer.GetHashCode(c));
        }

        [TestMethod]
        public void Valid_Expression_Returns_Expected_Results()
        {
            var comparer = InstanceComparer.For<TestClass>()
                .AddExpression(t => t.StringProperty.EndsWith("a"));

            var a = new TestClass { StringProperty = "cba" };
            var b = new TestClass { StringProperty = "a" };
            var c = new TestClass { StringProperty = "b" };

            Assert.IsTrue(comparer.Equals(a, a));
            Assert.IsTrue(comparer.Equals(b, b));
            Assert.IsTrue(comparer.Equals(a, b));
            Assert.IsFalse(comparer.Equals(a, null));
            Assert.IsFalse(comparer.Equals(b, null));
            Assert.IsFalse(comparer.Equals(c, null));
            Assert.IsFalse(comparer.Equals(a, c));
            Assert.IsFalse(comparer.Equals(b, c));

            Assert.AreEqual(comparer.GetHashCode(a), comparer.GetHashCode(b));
            Assert.AreNotEqual(comparer.GetHashCode(a), comparer.GetHashCode(c));
            Assert.AreNotEqual(comparer.GetHashCode(b), comparer.GetHashCode(c));
        }

        [TestMethod]
        public void Nested_Property_Returns_Expected_False_Results_When_Used_As_Expression()
        {
            var comparer = InstanceComparer.For<TestClass>()
                .AddExpression(t => t.ComplexProperty.NumberProperty);

            var a = new TestClass {ComplexProperty = new TestSubClass {NumberProperty = 1}};
            var b = new TestClass {ComplexProperty = new TestSubClass {NumberProperty = 2}};

            Assert.IsFalse(comparer.Equals(a, b));
            Assert.AreEqual(1.GetHashCode(), a.ComplexProperty.NumberProperty.GetHashCode());
            Assert.AreEqual(2.GetHashCode(), b.ComplexProperty.NumberProperty.GetHashCode());
        }

        [TestMethod]
        public void Nested_Property_Returns_Expected_True_Results_When_Used_As_Expression()
        {
            var comparer = InstanceComparer.For<TestClass>()
                .AddExpression(t => t.ComplexProperty.NumberProperty);

            var a = new TestClass { ComplexProperty = new TestSubClass { NumberProperty = 1 } };
            var b = new TestClass { ComplexProperty = new TestSubClass { NumberProperty = 1 } };

            Assert.IsTrue(comparer.Equals(a, b));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Property_Expression_Throws_Exception()
        {
            Expression<Func<TestClass, string>> expr = null;
            var comparer = InstanceComparer.For<TestClass>().AddProperty(expr, StringComparer.OrdinalIgnoreCase);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_Property_Expression_Throws_Exception()
        {
            var comparer = InstanceComparer.For<TestClass>()
                .AddProperty(c => c.StringField, StringComparer.OrdinalIgnoreCase);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Field_Expression_Throws_Exception()
        {
            Expression<Func<TestClass, string>> expr = null;
            var comparer = InstanceComparer.For<TestClass>().AddField(expr, StringComparer.OrdinalIgnoreCase);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_Field_Expression_Throws_Exception()
        {
            var comparer = InstanceComparer.For<TestClass>()
                .AddField(c => c.StringProperty, StringComparer.OrdinalIgnoreCase);
            Assert.Fail();
        }

        public class TestClass
        {
            public string StringField;
            public string StringProperty { get; set; }
            public string WriteOnlyProperty { set => StringField = value; }
            public int NumberProperty { get; set; }
            public TestSubClass ComplexProperty { get; set; }
        }

        public class TestSubClass
        {
            public string StringProperty { get; set; }
            public int NumberProperty { get; set; }
        }
    }
}
