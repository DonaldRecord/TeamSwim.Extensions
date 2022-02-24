using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Reflection
{
    [TestClass]
    public class PropertyInfoHasCustomAttributesTests
    {
        [TestMethod]
        public void Returns_Expected_Single_Results()
        {
            var actual = WithSingleAttribute.TestProp.HasCustomAttributes<TestSingleAttribute>(out var attr);
            Assert.IsTrue(actual);
            Assert.AreEqual(1, attr.Count);
            Assert.IsNotNull(attr);

            actual = WithoutSingleAttribute.TestProp.HasCustomAttributes(out attr);
            Assert.IsFalse(actual);
            Assert.AreEqual(0, attr.Count);
            Assert.IsNotNull(attr);
        }

        [TestMethod]
        public void Returns_Expected_Multiple_Results()
        {
            var actual = WithOneMultipleAttribute.TestProp.HasCustomAttributes<TestMultipleAttribute>(out var attr);
            Assert.AreEqual(1, attr.Count);
            Assert.IsNotNull(attr);

            actual = WithoutMultipleAttribute.TestProp.HasCustomAttributes(out attr);
            Assert.IsFalse(actual);
            Assert.IsNotNull(attr);

            actual = WithManyMultipleAttribute.TestProp.HasCustomAttributes(out attr);
            Assert.AreEqual(3, attr.Count);
            Assert.IsNotNull(attr);
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        class TestSingleAttribute : Attribute { }

        class WithSingleAttribute
        {
            public static PropertyInfo TestProp => typeof(WithSingleAttribute).GetProperty(nameof(Prop));

            [TestSingle]
            public string Prop { get; set; }
        }

        class WithoutSingleAttribute
        {
            public static PropertyInfo TestProp => typeof(WithoutSingleAttribute).GetProperty(nameof(Prop));

            // [TestSingle]
            public string Prop { get; set; }
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        class TestMultipleAttribute : Attribute { }

        class WithOneMultipleAttribute
        {
            public static PropertyInfo TestProp => typeof(WithOneMultipleAttribute).GetProperty(nameof(Prop));

            [TestMultiple]
            public string Prop { get; set; }
        }

        class WithManyMultipleAttribute
        {
            public static PropertyInfo TestProp => typeof(WithManyMultipleAttribute).GetProperty(nameof(Prop));

            [TestMultiple, TestMultiple, TestMultiple]
            public string Prop { get; set; }
        }

        class WithoutMultipleAttribute
        {
            public static PropertyInfo TestProp => typeof(WithoutMultipleAttribute).GetProperty(nameof(Prop));

            // [TestMultiple]
            public string Prop { get; set; }
        }
    }
}