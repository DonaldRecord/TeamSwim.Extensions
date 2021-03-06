﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class NotNullTests
    {
        [TestMethod]
        public void Message_1()
        {
            var list = new List<int> {1, 2};
            var x = list.Single();
        }

        [TestMethod]
        public void Returns_Expected_Value()
        {
            string str1 = null;
            var str2 = Utility.RandomString();
            var list = new List<string> {str1, str2};

            var uut = list.NotNull();

            Assert.IsInstanceOfType(uut, typeof(IEnumerable<string>));
            Assert.AreEqual(1, uut.Count());
            Assert.AreEqual(str2, uut.ToList()[0]);
        }
    }
}
