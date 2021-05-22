using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemDayOfWeek.Tests
{
    [TestClass]
    public class DayOfWeekIsWeekendTests
    {
        [TestMethod]
        public void Monday_Returns_False()
        {
            Assert.IsFalse(DayOfWeek.Monday.IsWeekend());
        }

        [TestMethod]
        public void Tuesday_Returns_False()
        {
            Assert.IsFalse(DayOfWeek.Tuesday.IsWeekend());
        }

        [TestMethod]
        public void Wednesday_Returns_False()
        {
            Assert.IsFalse(DayOfWeek.Wednesday.IsWeekend());
        }

        [TestMethod]
        public void Thursday_Returns_False()
        {
            Assert.IsFalse(DayOfWeek.Thursday.IsWeekend());
        }

        [TestMethod]
        public void Friday_Returns_False()
        {
            Assert.IsFalse(DayOfWeek.Friday.IsWeekend());
        }

        [TestMethod]
        public void Saturday_Returns_True()
        {
            Assert.IsTrue(DayOfWeek.Saturday.IsWeekend());
        }

        [TestMethod]
        public void Sunday_Returns_True()
        {
            Assert.IsTrue(DayOfWeek.Sunday.IsWeekend());
        }
    }
}
