using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class FlattenTests
    {
        [TestMethod]
        public void Flatten_Single_Nesting_Returns_Expected_Results()
        {
            var c = new TestClass(1, 2).Yield();

            var actual = c.Flatten(x => x.Child).ToList();

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(1, actual[0].Id);
            Assert.AreEqual(2, actual[1].Id);
        }

        [TestMethod]
        public void Flatten_Multiple_Nesting_Returns_Expected_Results()
        {
            var c = new TestClass(1, 2, 3, 4, 5, 6).Yield();

            var actual = c.Flatten(x => x.Child).ToList();

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
            var c = new TestClass(1, null).Yield();

            var actual = c.Flatten(x => x.Child).ToList();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(1, actual[0].Id);
        }

        [TestMethod]
        public void Assert_Null_Sub_Child_Behavior()
        {
            var c = new TestClass(1, new TestClass(2, null)).Yield();
            
            var actual = c.Flatten(x => x.Child).ToList();
            
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(1, actual[0].Id);
            Assert.AreEqual(2, actual[1].Id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Assert_Error_Not_Handled()
        {
            var c = new TestClass(1, new TestClass(2, null)).Yield();
            
            c.Flatten(x => throw new NotSupportedException()).ToList();
            
            Assert.Fail();
        }

        class TestClass
        {
            public int Id { get; set; }
            public TestClass Child { get; set; }

            public TestClass(params int[] ids)
            {
                if (ids.IsNullOrEmpty())
                    throw new ArgumentNullException(nameof(ids));
                
                var id = ids[0];
                Id = id;

                var childIds = ids.Skip(1).ToList();
                if (childIds.Any())
                    Child = new TestClass(childIds.ToArray());
            }

            public TestClass(int id, TestClass child)
            {
                Id = id;
                Child = child;
            }
        }
    }
}
