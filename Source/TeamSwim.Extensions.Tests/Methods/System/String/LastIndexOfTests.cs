using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class LastIndexOfTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Throws_Exception()
        {
            string uut = null;
            var actual = uut.LastIndexOf(c => c == 'c');
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Predicate_Throws_Exception()
        {
            var uut = "1111";
            Func<char, bool> predicate = null;
            var actual = uut.LastIndexOf(predicate);
            Assert.Fail();
        }

        [TestMethod]
        public void Empty_Returns_Expected_Result()
        {
            var uut = String.Empty;
            var actual = uut.LastIndexOf(c => c == ' ');
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void Returns_Expected_Not_Found()
        {
            var uut = "ab";
            var actual = uut.LastIndexOf(c => c == 'c');
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void Returns_Expected_Found_Single_Find()
        {
            var uut = "a1";
            var actual = uut.LastIndexOf(c => c == '1');
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Returns_Expected_Found_Multiple_Find()
        {
            var uut = "1111";
            var actual = uut.LastIndexOf(c => c == '1');
            Assert.AreEqual(3, actual);
        }
    }
}
