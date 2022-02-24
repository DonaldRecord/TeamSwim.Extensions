using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Reflection
{
    [TestClass]
    public class PropertyInfoHasCustomAttributeTests
    {
        [TestMethod]
        public void Returns_Expected_Single_Results()
        {
            var actual = WithSingleAttribute.TestProp.HasCustomAttribute<TestSingleAttribute>(out var attr);
            Assert.IsTrue(actual);
            Assert.IsNotNull(attr);

            actual = WithoutSingleAttribute.TestProp.HasCustomAttribute<TestSingleAttribute>(out attr);
            Assert.IsFalse(actual);
            Assert.IsNull(attr);
        }

        [TestMethod]
        public void Returns_Expected_Multiple_Results()
        {
            var actual = WithOneMultipleAttribute.TestProp.HasCustomAttribute<TestMultipleAttribute>(out var attr);
            Assert.IsTrue(actual);
            Assert.IsNotNull(attr);

            actual = WithoutMultipleAttribute.TestProp.HasCustomAttribute(out attr);
            Assert.IsFalse(actual);
            Assert.IsNull(attr);

            Assert.ThrowsException<AmbiguousMatchException>(() => WithManyMultipleAttribute.TestProp.HasCustomAttribute(out attr));
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
