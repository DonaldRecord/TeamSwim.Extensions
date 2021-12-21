using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Reflection
{
    [TestClass]
    public class HasCustomAttributeTests
    {
        [TestMethod]
        public void Returns_Expected_Single_Results()
        {
            var actual = typeof(WithSingleAttribute).HasCustomAttribute<TestSingleAttribute>(out var attr);
            Assert.IsTrue(actual);
            Assert.IsNotNull(attr);

            actual = typeof(WithoutSingleAttribute).HasCustomAttribute(out attr);
            Assert.IsFalse(actual);
            Assert.IsNull(attr);
        }

        [TestMethod]
        public void Returns_Expected_Multiple_Results()
        {
            var actual = typeof(WithOneMultipleAttribute).HasCustomAttribute<TestMultipleAttribute>(out var attr);
            Assert.IsTrue(actual);
            Assert.IsNotNull(attr);

            actual = typeof(WithoutMultipleAttribute).HasCustomAttribute(out attr);
            Assert.IsFalse(actual);
            Assert.IsNull(attr);

            Assert.ThrowsException<AmbiguousMatchException>(() => typeof(WithManyMultipleAttribute).HasCustomAttribute(out attr));
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
