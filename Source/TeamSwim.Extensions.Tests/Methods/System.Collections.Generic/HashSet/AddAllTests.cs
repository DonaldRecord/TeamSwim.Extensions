using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Collections.Generic.HashSet
{
    [TestClass]
    public class AddAllTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Null_Hashset_Throws()
        {
            HashSet<int> set = null;
            var actual = set.AddAll(3, 4, 5);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Argument_Throws()
        {
            var set = new HashSet<int> { 1, 2, 3 };
            var actual = set.AddAll(null);
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_False_For_Partial()
        {
            var set = new HashSet<int> {1, 2, 3};
            var actual = set.AddAll(3, 4, 5);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Returns_False_For_None()
        {
            var set = new HashSet<int> {1, 2, 3};
            var actual = set.AddAll(1, 2, 3);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Returns_True_For_All()
        {
            var set = new HashSet<int> {1, 2, 3};
            var actual = set.AddAll(4, 5, 6);
            Assert.IsTrue(actual);
        }
    }
}
