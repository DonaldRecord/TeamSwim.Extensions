//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Text;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace System.Classes
//{
//    [TestClass]
//    public class InstanceComparerTests
//    {
//        [TestMethod]
//        public void Valid_Property_Expression_Returns_Expected_Results()
//        {
//            var comparer = new InstanceComparer<TestClass>()
//                .AddProperty(c => c.StringProperty, StringComparer.OrdinalIgnoreCase);

//            var a = new TestClass {StringProperty = "a"};
//            var b = new TestClass {StringProperty = "A"};
//            var c = new TestClass {StringProperty = "b"};

//            Assert.IsTrue(comparer.Equals(a, a));
//            Assert.IsTrue(comparer.Equals(b, b));
//            Assert.IsTrue(comparer.Equals(a, b));
//            Assert.IsFalse(comparer.Equals(a, null));
//            Assert.IsFalse(comparer.Equals(b, null));
//            Assert.IsFalse(comparer.Equals(c, null));
//            Assert.IsFalse(comparer.Equals(a, c));
//            Assert.IsFalse(comparer.Equals(b, c));

//            Assert.AreEqual(comparer.GetHashCode(a), comparer.GetHashCode(b));
//            Assert.AreNotEqual(comparer.GetHashCode(a), comparer.GetHashCode(c));
//            Assert.AreNotEqual(comparer.GetHashCode(b), comparer.GetHashCode(c));
//        }

//        [TestMethod]
//        public void Valid_Field_Expression_Returns_Expected_Results()
//        {
//            var comparer = new InstanceComparer<TestClass>()
//                .AddField(c => c.StringField, StringComparer.OrdinalIgnoreCase);

//            var a = new TestClass { StringField = "a" };
//            var b = new TestClass { StringField = "A" };
//            var c = new TestClass { StringField = "b" };

//            Assert.IsTrue(comparer.Equals(a, a));
//            Assert.IsTrue(comparer.Equals(b, b));
//            Assert.IsTrue(comparer.Equals(a, b));
//            Assert.IsFalse(comparer.Equals(a, null));
//            Assert.IsFalse(comparer.Equals(b, null));
//            Assert.IsFalse(comparer.Equals(c, null));
//            Assert.IsFalse(comparer.Equals(a, c));
//            Assert.IsFalse(comparer.Equals(b, c));

//            Assert.AreEqual(comparer.GetHashCode(a), comparer.GetHashCode(b));
//            Assert.AreNotEqual(comparer.GetHashCode(a), comparer.GetHashCode(c));
//            Assert.AreNotEqual(comparer.GetHashCode(b), comparer.GetHashCode(c));
//        }

//        [TestMethod]
//        public void Valid_Expression_Returns_Expected_Results()
//        {
//            var comparer = new InstanceComparer<TestClass>()
//                .AddExpression(t => t.StringProperty.EndsWith("a"));

//            var a = new TestClass {StringField = "cba"};
//            var b = new TestClass {StringField = "a"};
//            var c = new TestClass {StringField = "b"};

//            Assert.IsTrue(comparer.Equals(a, a));
//            Assert.IsTrue(comparer.Equals(b, b));
//            Assert.IsTrue(comparer.Equals(a, b));
//            Assert.IsFalse(comparer.Equals(a, null));
//            Assert.IsFalse(comparer.Equals(b, null));
//            Assert.IsFalse(comparer.Equals(c, null));
//            Assert.IsFalse(comparer.Equals(a, c));
//            Assert.IsFalse(comparer.Equals(b, c));

//            Assert.AreEqual(comparer.GetHashCode(a), comparer.GetHashCode(b));
//            Assert.AreNotEqual(comparer.GetHashCode(a), comparer.GetHashCode(c));
//            Assert.AreNotEqual(comparer.GetHashCode(b), comparer.GetHashCode(c));
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void Null_Property_Expression_Throws_Exception()
//        {
//            Expression<Func<TestClass, string>> expr = null;
//            var comparer = new InstanceComparer<TestClass>().AddProperty(expr, StringComparer.OrdinalIgnoreCase);
//            Assert.Fail();
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Invalid_Property_Expression_Throws_Exception()
//        {
//            var comparer = new InstanceComparer<TestClass>()
//                .AddProperty(c => c.StringField, StringComparer.OrdinalIgnoreCase);
//            Assert.Fail();
//        }

//        //[TestMethod]
//        //[ExpectedException(typeof(ArgumentException))]
//        //public void WriteOnly_Property_Expression_Throws_Exception()
//        //{
//        //    var comparer = new InstanceComparer<TestClass>()
//        //        .AddProperty(c => c.WriteOnlyProperty, StringComparer.OrdinalIgnoreCase);
//        //    Assert.Fail();
//        //}

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void Null_Field_Expression_Throws_Exception()
//        {
//            Expression<Func<TestClass, string>> expr = null;
//            var comparer = new InstanceComparer<TestClass>().AddField(expr, StringComparer.OrdinalIgnoreCase);
//            Assert.Fail();
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Invalid_Field_Expression_Throws_Exception()
//        {
//            var comparer = new InstanceComparer<TestClass>()
//                .AddField(c => c.StringProperty, StringComparer.OrdinalIgnoreCase);
//            Assert.Fail();
//        }

//        public class TestClass
//        {
//            public string StringField;
//            public string StringProperty { get; set; }
//            public string WriteOnlyProperty { set => StringField = value; }
//            public int NumberProperty { get; set; }
//            public TestSubClass ComplexProperty { get; set; }
//        }

//        public class TestSubClass
//        {
//            public string StringProperty { get; set; }
//            public int NumberProperty { get; set; }
//        }
//    }
//}
