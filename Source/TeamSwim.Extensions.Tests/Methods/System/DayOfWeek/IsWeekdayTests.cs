using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class DayOfWeekIsWeekdayTests
    {
        [TestMethod]
        public void Monday_Returns_True()
        {
            Assert.IsTrue(DayOfWeek.Monday.IsWeekday());
        }

        [TestMethod]
        public void Tuesday_Returns_True()
        {
            Assert.IsTrue(DayOfWeek.Tuesday.IsWeekday());
        }

        [TestMethod]
        public void Wednesday_Returns_True()
        {
            Assert.IsTrue(DayOfWeek.Wednesday.IsWeekday());
        }

        [TestMethod]
        public void Thursday_Returns_True()
        {
            Assert.IsTrue(DayOfWeek.Thursday.IsWeekday());
        }

        [TestMethod]
        public void Friday_Returns_True()
        {
            Assert.IsTrue(DayOfWeek.Friday.IsWeekday());
        }

        [TestMethod]
        public void Saturday_Returns_False()
        {
            Assert.IsFalse(DayOfWeek.Saturday.IsWeekday());
        }

        [TestMethod]
        public void Sunday_Returns_False()
        {
            Assert.IsFalse(DayOfWeek.Sunday.IsWeekday());
        }
    }
}
