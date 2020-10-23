using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class OrderByDependencyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            List<TestClass> source = null;

            var actual = source
                .OrderByDependency(TestClass.ReferenceKey, TestClass.Dependents)
                .ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Reference_Key_Throws_Exception()
        {
            var source = new List<TestClass> {new TestClass(1, 2, 3)};

            var actual = source
                .OrderByDependency(null, TestClass.Dependents)
                .ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Dependents_Throws_Exception()
        {
            var source = new List<TestClass> { new TestClass(1, 2, 3) };

            var actual = source
                .OrderByDependency(TestClass.ReferenceKey, null)
                .ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Circular_Reference_Throws_Exception()
        {
            var source = new List<TestClass>
            {
                new TestClass(1, 2),
                new TestClass(2, 1)
            };

            var actual = source
                .OrderByDependency(TestClass.ReferenceKey, TestClass.Dependents)
                .ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Order_Is_Maintained_Without_Any_Dependencies()
        {
            var source = new List<TestClass>
            {
                new TestClass(1),
                new TestClass(2),
                new TestClass(3),
            };

            var actual = source
                .OrderByDependency(TestClass.ReferenceKey, TestClass.Dependents)
                .ToList();
            Assert.AreEqual(1, actual[0].Value);
            Assert.AreEqual(2, actual[1].Value);
            Assert.AreEqual(3, actual[2].Value);
        }

        [TestMethod]
        public void Self_Reference_Is_Ignored()
        {
            var source = new List<TestClass>
            {
                new TestClass(1, 1, 1, 1),
                new TestClass(2, 2, 2, 2),
                new TestClass(3, 3, 3, 3),
            };

            var actual = source
                .OrderByDependency(TestClass.ReferenceKey, TestClass.Dependents)
                .ToList();
            Assert.AreEqual(1, actual[0].Value);
            Assert.AreEqual(2, actual[1].Value);
            Assert.AreEqual(3, actual[2].Value);
        }

        [TestMethod]
        public void Returns_Expected_Results()
        {
            var source = new List<TestClass>
            {
                new TestClass(1, 2),
                new TestClass(2, 3),
                new TestClass(3)
            };

            var actual = source
                .OrderByDependency(TestClass.ReferenceKey, TestClass.Dependents)
                .ToList();
            Assert.AreEqual(3, actual[0].Value);
            Assert.AreEqual(2, actual[1].Value);
            Assert.AreEqual(1, actual[2].Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Null_Element_Throws_Argument_Exception()
        {
            var source = new List<TestClass>
            {
                new TestClass(1, 2),
                new TestClass(2, 3),
                new TestClass(3),
                null
            };

            var actual = source
                .OrderByDependency(TestClass.ReferenceKey, TestClass.Dependents)
                .ToList();
            Assert.Fail();
        }

        public class TestClass
        {
            public int Value { get; }
            public List<int> Dependencies { get; }

            public TestClass(int value, params int[] dependencies)
            {
                Value = value;
                Dependencies = dependencies.ToList();
            }

            public static Func<TestClass, int> ReferenceKey => c => c.Value;
            public static Func<TestClass, IEnumerable<int>> Dependents => c => c.Dependencies;
        }
    }
}
