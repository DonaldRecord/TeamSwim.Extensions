using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class IsWeekendTests
    {
        [TestMethod]
        public void Returns_False_For_Monday()
        {
            var dt = new DateTime(2020, 10, 5);
            Assert.IsFalse(dt.IsWeekend());
        }

        [TestMethod]
        public void Returns_False_For_Tuesday()
        {
            var dt = new DateTime(2020, 10, 6);
            Assert.IsFalse(dt.IsWeekend());
        }

        [TestMethod]
        public void Returns_False_For_Wednesday()
        {
            var dt = new DateTime(2020, 10, 7);
            Assert.IsFalse(dt.IsWeekend());
        }

        [TestMethod]
        public void Returns_False_For_Thursday()
        {
            var dt = new DateTime(2020, 10, 8);
            Assert.IsFalse(dt.IsWeekend());
        }

        [TestMethod]
        public void Returns_False_For_Friday()
        {
            var dt = new DateTime(2020, 10, 9);
            Assert.IsFalse(dt.IsWeekend());
        }

        [TestMethod]
        public void Returns_True_For_Saturday()
        {
            var dt = new DateTime(2020, 10, 10);
            Assert.IsTrue(dt.IsWeekend());
        }

        [TestMethod]
        public void Returns_True_For_Sunday()
        {
            var dt = new DateTime(2020, 10, 10);
            Assert.IsTrue(dt.IsWeekend());
        }
    }
}
