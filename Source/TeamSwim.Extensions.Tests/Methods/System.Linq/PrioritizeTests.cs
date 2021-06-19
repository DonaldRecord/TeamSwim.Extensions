using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class PrioritizeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            List<int> source = null;
            var actual = source.Prioritize(i => i % 2 == 0).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Predicate_Throws_Exception()
        {
            var source = new List<int> {1, 2, 3, 4};
            Func<int, bool> predicate = null;
            var actual = source.Prioritize(predicate).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Prioritize_Returns_Expected_Order()
        {
            var list = new List<int> {1, 2, 3, 4};
            var uut = list.Prioritize(i => i % 2 == 0).ToList();

            Assert.AreEqual(2, uut[0]);
            Assert.AreEqual(4, uut[1]);
            Assert.AreEqual(1, uut[2]);
            Assert.AreEqual(3, uut[3]);
        }
    }
}
