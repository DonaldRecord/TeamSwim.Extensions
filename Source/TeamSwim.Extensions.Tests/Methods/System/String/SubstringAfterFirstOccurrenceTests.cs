using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemString.Tests
{
    [TestClass]
    public class SubstringAfterFirstOccurrenceTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Throws_Expected_Null_Reference_Exception()
        {
            string str = null;
            var actual = str.SubstringAfterFirstOccurrence("b");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Expected_Argument_Null_Exception()
        {
            var actual = "abc".SubstringAfterFirstOccurrence(null);
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Expected_Value()
        {
            var actual = "abc".SubstringAfterFirstOccurrence("AB", StringComparison.OrdinalIgnoreCase);
            Assert.AreEqual("c", actual);
        }

        [TestMethod]
        public void Returns_Expected_Null_Value()
        {
            var actual = "abc".SubstringAfterFirstOccurrence("d", StringComparison.OrdinalIgnoreCase);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void No_Errors_For_Zero_Width_String()
        {
            var actual = "".SubstringAfterFirstOccurrence("d", StringComparison.OrdinalIgnoreCase);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Zero_Width_Argument_Always_Returns_Null()
        {
            var actual = "".SubstringAfterFirstOccurrence("", StringComparison.OrdinalIgnoreCase);
            Assert.IsNull(actual);
        }
    }
}
