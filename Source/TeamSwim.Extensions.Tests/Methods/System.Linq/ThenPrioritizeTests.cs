﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class ThenPrioritizeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            IOrderedEnumerable<int> list = null;
            var result = list.ThenPrioritize(i => i % 4 == 0);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Predicate_Throws_Exception()
        {
            Func<int, bool> predicate = null;
            var list = new List<int> { 1, 2, 3 };

            var result = list.Prioritize(i => i > 0).ThenPrioritize(predicate);
            Assert.Fail();
        }

        [TestMethod]
        public void ThenPrioritize_Returns_Expected_Order()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var uut = list
                .Prioritize(i => i % 2 == 0)
                .ThenPrioritize(i => i % 4 == 0)
                .ToList();

            Assert.AreEqual(4, uut[0]);
            Assert.AreEqual(2, uut[1]);
            Assert.AreEqual(1, uut[2]);
            Assert.AreEqual(3, uut[3]);
        }

        [TestMethod]
        public void ThenPrioritize_Returns_Expected_Chained_Order()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var uut = list
                .Prioritize(i => i % 2 == 0)
                .ThenPrioritize(i => i % 4 == 0)
                .ThenPrioritize(i => i % 3 == 0)
                .ThenPrioritize(i => i % 2 == 0) // this one shouldn't make a difference
                .ToList();

            Assert.AreEqual(4, uut[0]);
            Assert.AreEqual(2, uut[1]);
            Assert.AreEqual(3, uut[2]);
            Assert.AreEqual(1, uut[3]);
        }
    }
}
