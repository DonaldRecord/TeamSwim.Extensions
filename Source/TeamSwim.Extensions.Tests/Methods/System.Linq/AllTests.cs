using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class AllTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void All_Null_Source_Throws_Exception()
        {
            List<int> list = null;

            var result = list.All((i, idx) => i == -1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void All_Null_Predicate_Throws_Exception()
        {
            Func<int, int, bool> predicate = null;
            var list = new List<int> {1, 2, 3};

            var result = list.All(predicate);

            Assert.Fail();
        }

        [TestMethod]
        public void All_Returns_Expected_True()
        {
            var list = new List<int> { 1, 2, 3 };
            var result = list.All((i1, i2) => i1 == i2 + 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void All_Returns_Expected_False()
        {
            var list = new List<int> { 1, 2, 3 };
            var result = list.All((i1, i2) => i1 == i2);
            Assert.IsFalse(result);
        }
    }
}
