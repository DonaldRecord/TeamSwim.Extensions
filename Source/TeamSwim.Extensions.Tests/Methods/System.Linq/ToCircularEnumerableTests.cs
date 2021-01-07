using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class ToCircularEnumerableTests
    {
        [TestMethod]
        public void Iterating_Would_Cause_StackOverflowException()
        {
            var list = new List<int> { 1, 2, 3 };
            var hypotheticalLength = list.Count * 200;
            var uut = list.ToCircularEnumerable().Take(hypotheticalLength).ToList();
            Assert.AreEqual(hypotheticalLength, uut.Count);
        }

        [TestMethod]
        public void Non_Looping_Index_Returns_Expected_Value()
        {
            var list = new List<int> { 1, 2, 3 };
            var elem = list.ToCircularEnumerable().ElementAt(0);
            Assert.AreEqual(1, elem);
        }

        [TestMethod]
        public void Looping_Index_Returns_Expected_Value()
        {
            var list = new List<int> { 1, 2, 3 };
            var elem = list.ToCircularEnumerable().ElementAt(4);
            Assert.AreEqual(2, elem);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Negative_ElementAt_Throws_Exception()
        {
            var list = new List<int> { 1, 2, 3 };
            var elem = list.ToCircularEnumerable().ElementAt(-1);
            Assert.Fail();
        }
    }
}
