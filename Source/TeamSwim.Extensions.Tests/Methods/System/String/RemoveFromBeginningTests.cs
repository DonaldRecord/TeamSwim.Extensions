using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    [TestClass]
    public class RemoveFromBeginningTests
    {
        [TestMethod]
        public void Throws_Expected_Exceptions()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ((string)null).RemoveFromBeginning(""));
            Assert.ThrowsException<ArgumentNullException>(() => "".RemoveFromBeginning(null));
        }

        [TestMethod]
        public void Assert_String_Empty_Value_ReferenceEquals()
        {
            var value = "";
            var result = value.RemoveFromBeginning("asdf");
            Assert.IsTrue(ReferenceEquals(value, result));
        }

        [TestMethod]
        public void Assert_String_Empty_Substring_ReferenceEquals()
        {
            var value = "asdf";
            var result = value.RemoveFromBeginning("");
            Assert.IsTrue(ReferenceEquals(value, result));
        }

        [TestMethod]
        public void Assert_Expected_Results()
        {
            void AssertValue(string value, string substring, StringComparison stringComparison, string expected)
            {
                var actual = value.RemoveFromBeginning(substring, stringComparison);
                Assert.AreEqual(expected, actual);
            }

            AssertValue("AAABBB", "AAA", StringComparison.Ordinal, "BBB");
            AssertValue("AAABBB", "aaa", StringComparison.OrdinalIgnoreCase, "BBB");
            AssertValue("ccc", "aaa", StringComparison.Ordinal, "ccc");
            AssertValue("a", "a", StringComparison.Ordinal, "");
        }
    }
}
