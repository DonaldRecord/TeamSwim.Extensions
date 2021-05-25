using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemInt32.Tests
{
    [TestClass]
    public class TryParseTests : BaseUnitTest
    {
        private const string TryParseTest = "Int32?.TryParse()";

        [TestMethod]
        public void Null_String_Returns_True()
        {
            string input = null;

            var actual = Int32Ext.TryParseNullable(input, out var i);

            Assert.IsTrue(actual);
            Assert.IsNull(i);
        }

        [TestMethod]
        public void Invalid_String_Returns_True()
        {
            string input = "abc";

            var actual = Int32Ext.TryParseNullable(input, out var i);

            Assert.IsFalse(actual);
            Assert.IsNull(i);
        }

        [TestMethod]
        public void Valid_String_Returns_True()
        {
            string input = "12";

            var actual = Int32Ext.TryParseNullable(input, out var i);

            Assert.IsTrue(actual);
            Assert.AreEqual(12, i);
        }
    }
}
