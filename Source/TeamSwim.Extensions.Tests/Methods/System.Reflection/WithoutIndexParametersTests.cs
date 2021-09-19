using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Reflection
{
    [TestClass]
    public class WithoutIndexParametersTests
    {
        [TestMethod]
        public void Instance_Under_Test_Is_Valid()
        {
            Assert.AreEqual(2, TestEntity.InstanceUnderTest.Count());
        }

        [TestMethod]
        public void Returns_Expected_Count()
        {
            var uut = TestEntity.InstanceUnderTest.Append(null);
            var actual = uut.WithoutIndexParameters().ToList();
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Expected_Argument_Null()
        {
            List<PropertyInfo> uut = null;
            var actual = uut.WithoutIndexParameters().ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Null_Items_Filtered()
        {
            var uut = TestEntity.InstanceUnderTest.Append(null);
            var actual = uut.WithoutIndexParameters().Count();
            Assert.AreEqual(1, actual);
        }

        class TestEntity
        {
            public int RegularProperty { get; set; }

            public int this[int index]
            {
                get => index;
                set { }
            }

            public static int ExpectedPropertyCount { get; } = 1;
            public static IEnumerable<PropertyInfo> InstanceUnderTest => typeof(TestEntity).GetProperties();

        }
    }
}
