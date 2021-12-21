using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Reflection
{
    [TestClass]
    public class HasCustomAttributesTests
    {
        [TestMethod]
        public void Returns_Expected_Single_Results()
        {
            var actual = typeof(WithSingleAttribute).HasCustomAttributes<TestSingleAttribute>(out var attr);
            Assert.IsTrue(actual);
            Assert.AreEqual(1, attr.Count);
            Assert.IsNotNull(attr);

            actual = typeof(WithoutSingleAttribute).HasCustomAttributes(out attr);
            Assert.IsFalse(actual);
            Assert.AreEqual(0, attr.Count);
            Assert.IsNotNull(attr);
        }

        [TestMethod]
        public void Returns_Expected_Multiple_Results()
        {
            var actual = typeof(WithOneMultipleAttribute).HasCustomAttributes<TestMultipleAttribute>(out var attr);
            Assert.AreEqual(1, attr.Count);
            Assert.IsNotNull(attr);

            actual = typeof(WithoutMultipleAttribute).HasCustomAttributes(out attr);
            Assert.IsFalse(actual);
            Assert.IsNotNull(attr);

            actual = typeof(WithManyMultipleAttribute).HasCustomAttributes(out attr);
            Assert.AreEqual(3, attr.Count);
            Assert.IsNotNull(attr);
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        class TestSingleAttribute : Attribute { }
        [TestSingle] class WithSingleAttribute { }
        class WithoutSingleAttribute { }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        class TestMultipleAttribute : Attribute { }
        [TestMultiple] class WithOneMultipleAttribute { }
        [TestMultiple, TestMultiple, TestMultiple] class WithManyMultipleAttribute { }
        class WithoutMultipleAttribute { }
    }
}