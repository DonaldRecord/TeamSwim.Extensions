using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.System.Linq
{
    [TestClass]
    public class TapTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Tap_Null_Source_Throws_Exception()
        {
            List<TestEntity> list = null;
            var result = list.Tap(l => l.Number++).ToList();

            Assert.AreEqual(2, result[0].Number);
            Assert.AreEqual(3, result[1].Number);
            Assert.AreEqual(4, result[2].Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Tap_Null_Delegate_Throws_Exception()
        {
            Action<TestEntity> action = null;
            var list = new List<TestEntity>
            {
                new TestEntity(1),
                new TestEntity(2),
                new TestEntity(3)
            };

            var result = list.Tap(action).ToList();

            Assert.AreEqual(2, result[0].Number);
            Assert.AreEqual(3, result[1].Number);
            Assert.AreEqual(4, result[2].Number);
        }

        [TestMethod]
        public void Tap_Delegate_Is_Always_Executed()
        {
            var list = new List<TestEntity>
            {
                new TestEntity(1),
                new TestEntity(2),
                new TestEntity(3)
            };

            var result = list.Tap(l => l.Number++).ToList();

            Assert.AreEqual(2, result[0].Number);
            Assert.AreEqual(3, result[1].Number);
            Assert.AreEqual(4, result[2].Number);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Tap_Does_Not_Error_Handle()
        {
            var list = new List<TestEntity>
            {
                new TestEntity(1),
                new TestEntity(2),
                new TestEntity(3),
                null
            };

            var result = list.Tap(l => l.Number++).ToList();

            Assert.AreEqual(2, result[0].Number);
            Assert.AreEqual(3, result[1].Number);
            Assert.AreEqual(4, result[2].Number);
        }

        [TestMethod]
        public void Tap_Predicate_Filters_Out_Elements()
        {
            var list = new List<TestEntity>
            {
                new TestEntity(1),
                new TestEntity(2),
                new TestEntity(3)
            };

            var result = list.Tap(l => l.Number++, l => l.Number % 2 == 0).ToList();

            Assert.AreEqual(1, result[0].Number);
            Assert.AreEqual(3, result[1].Number);
            Assert.AreEqual(3, result[2].Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Tap_With_Indexer_Null_Source_Throws_Exception()
        {
            List<TestEntity> list = null;
            var result = list.Tap((l, i) => l.Number += i).ToList();

            Assert.AreEqual(2, result[0].Number);
            Assert.AreEqual(4, result[1].Number);
            Assert.AreEqual(7, result[2].Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Tap_With_Indexer_Null_Delegate_Throws_Exception()
        {
            Action<TestEntity, int> action = null;
            var list = new List<TestEntity>
            {
                new TestEntity(1),
                new TestEntity(2),
                new TestEntity(3)
            };

            var result = list.Tap(action).ToList();

            Assert.AreEqual(2, result[0].Number);
            Assert.AreEqual(4, result[1].Number);
            Assert.AreEqual(7, result[2].Number);
        }

        [TestMethod]
        public void Tap_With_Indexer_Delegate_Is_Always_Executed()
        {
            var list = new List<TestEntity>
            {
                new TestEntity(1),
                new TestEntity(2),
                new TestEntity(3)
            };

            var result = list.Tap((l, i) => l.Number += i).ToList();

            Assert.AreEqual(1, result[0].Number);
            Assert.AreEqual(3, result[1].Number);
            Assert.AreEqual(5, result[2].Number);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Tap_With_Indexer_Does_Not_Error_Handle()
        {
            var list = new List<TestEntity>
            {
                new TestEntity(1),
                new TestEntity(2),
                new TestEntity(3),
                null
            };

            var result = list.Tap((l, i) => l.Number += i).ToList();

            Assert.AreEqual(1, result[0].Number);
            Assert.AreEqual(3, result[1].Number);
            Assert.AreEqual(5, result[2].Number);
        }

        [TestMethod]
        public void Tap_With_Indexer_Predicate_Filters_Out_Elements()
        {
            var list = new List<TestEntity>
            {
                new TestEntity(1),
                new TestEntity(2),
                new TestEntity(3)
            };

            var result = list.Tap((l, i) => l.Number++, (l, i) => i % 2 == 0).ToList();

            Assert.AreEqual(2, result[0].Number);
            Assert.AreEqual(2, result[1].Number);
            Assert.AreEqual(4, result[2].Number);
        }

        public class TestEntity
        {
            public int Number { get; set; }

            public TestEntity(int number)
            {
                Number = number;
            }
        }
    }
}
