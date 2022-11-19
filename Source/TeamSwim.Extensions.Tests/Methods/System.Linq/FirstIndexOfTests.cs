using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class FirstIndexOfTests
    {
        [TestMethod]
        public void Throws_Expected_Exceptions()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ((IEnumerable<int>)null).FirstIndexOf(i => i % 1 == 0));
            Assert.ThrowsException<ArgumentNullException>(() => (new List<int> { 1, 2, 3}).FirstIndexOf((Func<int, bool>)null));
        }

        [TestMethod]
        public void Returns_Expected_Index()
        {
            var source = new List<int> { 1, 2, 3, 4, 5 };

            Assert.AreEqual(1, source.FirstIndexOf(i => i % 2 == 0));
            Assert.AreEqual(3, source.FirstIndexOf(i => i % 4 == 0));
        }

        [TestMethod]
        public void Returns_Expected_Non_Index()
        {
            var source = new List<int> { 1, 2, 3, 4, 5 };

            Assert.AreEqual(-1, source.FirstIndexOf(i => i == 6));
        }
    }
}
