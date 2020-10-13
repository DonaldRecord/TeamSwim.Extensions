using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class IsWeekdayTests
    {
        [TestMethod]
        public void Returns_True_For_Monday()
        {
            var dt = new DateTime(2020, 10, 5);
            Assert.IsTrue(dt.IsWeekday());
        }

        [TestMethod]
        public void Returns_True_For_Tuesday()
        {
            var dt = new DateTime(2020, 10, 6);
            Assert.IsTrue(dt.IsWeekday());
        }

        [TestMethod]
        public void Returns_True_For_Wednesday()
        {
            var dt = new DateTime(2020, 10, 7);
            Assert.IsTrue(dt.IsWeekday());
        }

        [TestMethod]
        public void Returns_True_For_Thursday()
        {
            var dt = new DateTime(2020, 10, 8);
            Assert.IsTrue(dt.IsWeekday());
        }

        [TestMethod]
        public void Returns_True_For_Friday()
        {
            var dt = new DateTime(2020, 10, 9);
            Assert.IsTrue(dt.IsWeekday());
        }
        
        [TestMethod]
        public void Returns_False_For_Saturday()
        {
            var dt = new DateTime(2020, 10, 10);
            Assert.IsFalse(dt.IsWeekday());
        }

        [TestMethod]
        public void Returns_False_For_Sunday()
        {
            var dt = new DateTime(2020, 10, 10);
            Assert.IsFalse(dt.IsWeekday());
        }
    }
}
