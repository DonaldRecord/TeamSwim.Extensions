using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class AppendTests
    {
        [TestMethod]
        public void Throws_Expected_Exception()
        {
            IEnumerable<Type> uut = null;
            Assert.ThrowsException<ArgumentNullException>(() => uut.Append<string>());
        }

        [TestMethod]
        public void Returns_Expected_Result()
        {
            var uut = new List<Type>{typeof(string)};
            uut = uut.Append<int>().ToList();

            Assert.AreEqual(2, uut.Count);
            Assert.AreEqual(typeof(int), uut[1]);
        }
    }
}
