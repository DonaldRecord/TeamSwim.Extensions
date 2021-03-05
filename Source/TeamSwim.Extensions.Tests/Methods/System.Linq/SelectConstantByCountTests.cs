using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class SelectConstantByCountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            IEnumerable<int> source = null;
            var actual = source.SelectConstantByCount(0, 1, 2);
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Expected_None_Result()
        {
            var source = new List<int>();
            var actual = source.SelectConstantByCount(0, 1, 2);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Returns_Expected_None_Default()
        {
            var source = new List<int>();
            var actual = source.SelectConstantByCount(oneConstant: 1, manyConstant: 2);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Returns_Expected_One_Result()
        {
            var source = new List<int> { 3 };
            var actual = source.SelectConstantByCount(0, 1, 2);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Returns_Expected_One_Default()
        {
            var source = new List<int> { 3 };
            var actual = source.SelectConstantByCount(noneConstant: 0, manyConstant: 2);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Returns_Expected_Many_Result()
        {
            var source = new List<int> { 1, 2, 3, 4 };
            var actual = source.SelectConstantByCount(0, 1, 10);
            Assert.AreEqual(10, actual);
        }

        [TestMethod]
        public void Returns_Expected_Many_Default()
        {
            var source = new List<int> { 1, 2, 3, 4 };
            var actual = source.SelectConstantByCount(0, 1);
            Assert.AreEqual(0, actual);
        }
    }
}
