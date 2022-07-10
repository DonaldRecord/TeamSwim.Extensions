using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Generic
{
    [TestClass]
    public class AnyEqualTests
    {
        [TestMethod]
        public void Returns_Expected_True()
        {
            Assert.IsTrue(EqualityComparer<int>.Default.AnyEqual(new[] { 1, 2 }, 1));
            Assert.IsTrue(EqualityComparer<int>.Default.AnyEqual(new[] { 1, 2 }, 2));
            Assert.IsTrue(StringComparer.OrdinalIgnoreCase.AnyEqual(new[] { "a" }, "A"));
        }

        [TestMethod]
        public void Returns_Expected_False()
        {
            Assert.IsFalse(EqualityComparer<int>.Default.AnyEqual(new[] { 1, 2 }, 3));
            Assert.IsFalse(StringComparer.Ordinal.AnyEqual(new[] { "a" }, "A"));
        }

        [TestMethod]
        public void Throw_Expected_Exceptions()
        {
            IEqualityComparer<int> comparer = null;
            IEnumerable<int> list = null;

            Assert.ThrowsException<ArgumentNullException>(() => comparer.AnyEqual(new[] { 1, 2 }, 1));
            Assert.ThrowsException<ArgumentNullException>(() => EqualityComparer<int>.Default.AnyEqual(list, 1));
        }
    }
}
