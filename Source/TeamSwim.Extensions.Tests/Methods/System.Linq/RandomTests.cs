using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class RandomTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            IEnumerable<string> source = null;
            var actual = source.Random();
            Assert.Fail();
        }

        [TestMethod]
        public void Empty_List_Returns_Default()
        {
            var source = new List<string>();
            var actual = source.Random();
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Returns_Random_Element()
        {
            var source = new List<int> {1, 2, 3};
            var actual = source.Random();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == 1 || actual == 2 || actual == 3);
        }
    }
}
