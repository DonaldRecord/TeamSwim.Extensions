using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class IsLowerCaseTests
    {
        [TestMethod]
        public void Returns_Expected_True()
        {
            void AssertTrue(params char[] values) => Assert.IsTrue(values.All(v => v.IsLowerCase()));

            AssertTrue('a', 'b', 'c', 'x', 'y', 'z');
        }

        [TestMethod]
        public void Returns_Expected_False()
        {
            void AssertTrue(char value) => Assert.IsFalse(value.IsLowerCase());

            AssertTrue('A');
            AssertTrue('0');
            AssertTrue('\t');
            AssertTrue('\r');
            AssertTrue('\r');
            AssertTrue('!');
        }
    }
}
