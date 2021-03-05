using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class SelectByCountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            IEnumerable<int> source = null;
            var actual = source.SelectByCount(() => 0, one: i => 1, ic => 2);
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Expected_None_Result()
        {
            var source = new List<int>();
            var actual = source.SelectByCount(() => 0, one: i => 1, ic => 2);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Returns_Expected_None_Default()
        {
            var source = new List<int>();
            var actual = source.SelectByCount(one: i => 1, many: ic => 2);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Returns_Expected_One_Result()
        {
            var source = new List<int> {3};
            var actual = source.SelectByCount(() => 0, one: i => 1, ic => 2);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Returns_Expected_One_Default()
        {
            var source = new List<int> { 3 };
            var actual = source.SelectByCount(none: () => 0, many: ic => 2);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Returns_Expected_Many_Result()
        {
            var source = new List<int> {1, 2, 3, 4};
            var actual = source.SelectByCount(() => 0, one: i => 1, ic => ic.Sum());
            Assert.AreEqual(1 + 2 + 3 + 4, actual);
        }

        [TestMethod]
        public void Returns_Expected_Many_Default()
        {
            var source = new List<int> { 1, 2, 3, 4 };
            var actual = source.SelectByCount(() => 0, one: i => 1);
            Assert.AreEqual(0, actual);
        }
    }
}
