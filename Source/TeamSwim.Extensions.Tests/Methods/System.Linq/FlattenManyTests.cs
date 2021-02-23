using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class FlattenManyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            IEnumerable<TestClass> c = null;
            var actual = c.FlattenMany(x => x.Children).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Delegate_Throws_Exception()
        {
            var c = new TestClass(2).Yield();
            var actual = c.FlattenMany(null).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void FlattenMany_Single_Nesting_Returns_Expected_Results()
        {
            var c = new TestClass(1)
                .AddChild(new TestClass(2))
                .AddChild(new TestClass(3))
                .Yield();

            var actual = c.FlattenMany(x => x.Children).ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(1, actual[0].Id);
            Assert.AreEqual(2, actual[1].Id);
            Assert.AreEqual(3, actual[2].Id);
        }

        [TestMethod]
        public void FlattenMany_Multiple_Nesting_Returns_Expected_Results()
        {
            var c = new TestClass(1)
                .AddChild(new TestClass(2)
                    .AddChild(new TestClass(3))
                    .AddChild(new TestClass(4)
                        .AddChild(new TestClass(5))))
                .AddChild(new TestClass(6))
                .Yield();

            var actual = c.FlattenMany(x => x.Children).ToList();

            Assert.AreEqual(6, actual.Count);
            Assert.AreEqual(1, actual[0].Id);
            Assert.AreEqual(2, actual[1].Id);
            Assert.AreEqual(3, actual[2].Id);
            Assert.AreEqual(4, actual[3].Id);
            Assert.AreEqual(5, actual[4].Id);
            Assert.AreEqual(6, actual[5].Id);
        }

        [TestMethod]
        public void Assert_Null_Child_Behavior()
        {
            var c = new TestClass(1) {Children = null}.Yield();

            var actual = c.FlattenMany(x => x.Children).ToList();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(1, actual[0].Id);
        }

        [TestMethod]
        public void Null_Elements_Succeed()
        {
            var c = new TestClass(1)
                .AddChild(new TestClass(2)
                    .AddChild(new TestClass(3))
                    .AddChild(null)
                    .AddChild(new TestClass(4)
                        .AddChild(new TestClass(5))))
                .AddChild(new TestClass(6))
                .Yield();

            var actual = c.FlattenMany(x => x.Children).ToList();

            Assert.AreEqual(6, actual.Count);
            Assert.AreEqual(1, actual[0].Id);
            Assert.AreEqual(2, actual[1].Id);
            Assert.AreEqual(3, actual[2].Id);
            Assert.AreEqual(4, actual[3].Id);
            Assert.AreEqual(5, actual[4].Id);
            Assert.AreEqual(6, actual[5].Id);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Assert_Error_Not_Handled()
        {
            var c = new TestClass(1).Yield();

            c.FlattenMany(x => throw new NotSupportedException()).ToList();

            Assert.Fail();
        }

        class TestClass
        {
            public int Id { get; set; }
            public ICollection<TestClass> Children { get; set; } = new List<TestClass>();

            public TestClass(int id)
            {
                Id = id;
            }

            public TestClass AddChild(TestClass c)
            {
                Children.Add(c);
                return this;
            }
        }
    }
}
