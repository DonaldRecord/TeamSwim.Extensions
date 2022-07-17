using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class IsUpperCaseTests
    {
        [TestMethod]
        public void Returns_Expected_True()
        {
            void AssertTrue(char value) => Assert.IsTrue(value.IsUpperCase());

            AssertTrue('A');
        }

        [TestMethod]
        public void Returns_Expected_False()
        {
            void AssertTrue(params char[] values) => Assert.IsFalse(values.All(v => v.IsUpperCase()));

            AssertTrue('a', 'b', 'c', 'x', 'y', 'z');
            AssertTrue('0');
            AssertTrue('\t');
            AssertTrue('\r');
            AssertTrue('\r');
            AssertTrue('!');
        }
    }
}