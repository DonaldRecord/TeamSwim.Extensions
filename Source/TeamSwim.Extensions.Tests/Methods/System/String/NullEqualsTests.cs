using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ExpressionIsAlwaysNull

namespace TeamSwim.Extensions.SystemString.Tests
{
    [TestClass]
    public class NullEqualsTests : BaseUnitTest
    {
        [TestMethod]
        public void Null_Strings_Return_True()
        {
            string a = null;
            string b = null;

            var result = a.NullEquals(b, StringComparison.CurrentCulture);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Null_Strings_Return_False_When_B_Is_Null()
        {
            string a = Utility.RandomString();
            string b = null;

            var result = a.NullEquals(b, StringComparison.CurrentCulture);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Null_Strings_Return_False_When_A_Is_Null()
        {
            string a = null;
            string b = Utility.RandomString();

            var result = a.NullEquals(b, StringComparison.CurrentCulture);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equal_Strings_Return_True()
        {
            var value = Utility.RandomString();

            string a = value;
            string b = value;

            var result = a.NullEquals(b, StringComparison.CurrentCulture);

            Assert.IsTrue(result);
        }
    }
}
