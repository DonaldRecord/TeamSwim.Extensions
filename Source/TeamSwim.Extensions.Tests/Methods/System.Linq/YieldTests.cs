using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class YieldTests
    {
        [TestMethod]
        public void Returns_Expected_Set()
        {
            var obj = Utility.RandomString();
            var uut = obj.Yield();

            Assert.IsInstanceOfType(uut, typeof(IEnumerable<string>));
            Assert.AreEqual(1, uut.Count());
            Assert.AreEqual(obj, uut.ToList()[0]);
        }
    }
}
