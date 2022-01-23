using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class ExceptTests
    {
        [TestMethod]
        public void Throws_Expected_Exception()
        {
            IEnumerable<Type> uut = null;
            Assert.ThrowsException<ArgumentNullException>(() => uut.Except<string>());
        }

        [TestMethod]
        public void Returns_Expected_Result()
        {
            var uut = new List<Type> { typeof(string), typeof(int) };
            uut = uut.Except<int>().ToList();

            Assert.AreEqual(1, uut.Count);
            Assert.AreEqual(typeof(string), uut[0]);
        }
    }
}