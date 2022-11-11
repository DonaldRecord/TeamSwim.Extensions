using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq.Expressions
{
    [TestClass]
    public class TryGetPropertiesTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Expression_Throws_Exception()
        {
            Expression<Func<TestEntity, object>> uut = null;
            var actual = uut.TryGetProperties(out var infos);
            Assert.Fail();
        }

        [TestMethod]
        public void Simple_Property_Returns_Expected_Result()
        {
            Expression<Func<TestEntity, object>> uut = e => e.SimpleProperty;
            var actual = uut.TryGetProperties(out var infos);

            Assert.AreEqual(1, infos.Count());
            Assert.IsTrue(actual);
        }
        
        [TestMethod]
        public void Complex_Property_Returns_Expected_Result()
        {
            Expression<Func<TestEntity, object>> uut = e => e.ComplexProperty.NestedSimpleProperty;
            var actual = uut.TryGetProperties(out var infos);

            Assert.AreEqual(2, infos.Count());
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Simple_Field_Returns_Expected_Nothing()
        {
            Expression<Func<TestEntity, object>> uut = e => e.SimpleField;
            var actual = uut.TryGetProperties(out var infos);

            Assert.AreEqual(0, infos.Count());
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Complex_Field_Returns_Expected_Nothing()
        {
            Expression<Func<TestEntity, object>> uut = e => e.ComplexField.NestedSimpleProperty;
            var actual = uut.TryGetProperties(out var infos);

            Assert.AreEqual(0, infos.Count());
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Constant_Expression_Returns_Expected_Nothing()
        {
            Expression<Func<TestEntity, object>> uut = e => "constant";
            var actual = uut.TryGetProperties(out var infos);

            Assert.AreEqual(0, infos.Count());
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Recursive_Property_Returns_Expected_Results()
        {
            Expression<Func<TestEntity, object>> uut = e => e
                .ComplexProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty;
            var actual = uut.TryGetProperties(out var infos);

            Assert.AreEqual(10, infos.Count);
            Assert.AreEqual(2, infos.Distinct().Count());
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Recursive_Property_Can_Be_Broken_By_Field()
        {
            Expression<Func<TestEntity, object>> uut = e => e
                .ComplexProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveProperty
                .TestRecursiveField
                .TestRecursiveProperty
                .TestRecursiveProperty;
            var actual = uut.TryGetProperties(out var infos);

            Assert.AreEqual(0, infos.Count());
            Assert.IsFalse(actual);
        }

        public class TestEntity
        {
            public string SimpleProperty { get; set; }
            public TestNestedEntity ComplexProperty { get; set; }
            public string SimpleField;
            public TestNestedEntity ComplexField;

            // Test index property
            public string this[int index]
            {
                get => index.ToString();
                set { }
            }
        }

        public class TestNestedEntity
        {
            public string NestedSimpleProperty { get; set; }
            public TestNestedEntity TestRecursiveProperty { get; set; }
            public TestNestedEntity TestRecursiveField;
        }
    }
}
