using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    [TestClass]
    public class NoneTests
    {
        [TestMethod]
        public void Expected_True()
        {
            Assert.IsTrue(new List<int> { 1, 2, 3, 4, 5 }.None(i => i == 6));
        }

        [TestMethod]
        public void Expected_False()
        {
            Assert.IsTrue(new List<int> { 1, 2, 3, 4, 5 }.None(i => i == 6));
        }

        [TestMethod]
        public void Expected_Error()
        {
            List<int> list = null;
            Func<int, bool> predicate = null;

            Assert.ThrowsException<ArgumentNullException>(() => list.None(i => i == 1));
            Assert.ThrowsException<ArgumentNullException>(() => new List<int>().None(predicate));
        }
    }
}
