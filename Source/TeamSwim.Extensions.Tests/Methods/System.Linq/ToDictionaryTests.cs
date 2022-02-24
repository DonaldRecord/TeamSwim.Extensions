using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class ToDictionaryTests
    {
        [TestMethod]
        public void Throws_Expected_Errors()
        {
            Func<int, int, int> selector = null;
            Assert.ThrowsException<ArgumentNullException>(() => ((List<int>)null).ToDictionary((e, i) => e, (e, i) => i));
            Assert.ThrowsException<ArgumentNullException>(() => new [] {1, 2, 3}.ToDictionary(selector, (e, i) => i));
            Assert.ThrowsException<ArgumentNullException>(() => new [] {1, 2, 3}.ToDictionary((e, i) => i, selector));
            Assert.ThrowsException<ArgumentException>(() => new[] { 1, 1 }.ToDictionary((e, i) => e, (e, i) => i));
        }

        [TestMethod]
        public void Returns_Expected_Result()
        {
            var source = new List<string> { "a", "b", "c" };
            var actual = source.ToDictionary((s, i) => s, (s, i) => i + 1);
            Assert.AreEqual("a", actual.Keys.ElementAt(0));
            Assert.AreEqual("b", actual.Keys.ElementAt(1));
            Assert.AreEqual("c", actual.Keys.ElementAt(2));
            Assert.AreEqual(1, actual.Values.ElementAt(0));
            Assert.AreEqual(2, actual.Values.ElementAt(1));
            Assert.AreEqual(3, actual.Values.ElementAt(2));
        }
    }
}
