using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.System.Int64Extensions
{
    [TestClass]
    public class BetweenTests : BaseUnitTest
    {
        private const string BetweenTest = "Int64.Between()";

        [TestMethod]
        public void Inclusive_Value_Equals_Start_Returns_True()
        {
            long start = 1;
            long end = 5;
            long value = 1;

            Assert.IsTrue(value.Between(start, end, true));
            Assert.IsTrue(value.Between(start, end));
        }

        [TestMethod]
        public void Inclusive_Value_Equals_End_Returns_True()
        {
            long start = 1;
            long end = 5;
            long value = 5;

            Assert.IsTrue(value.Between(start, end, true));
            Assert.IsTrue(value.Between(start, end));
        }

        [TestMethod]
        public void Inclusive_Value_Not_Between_Start_And_End_Returns_False()
        {
            long start = 1;
            long end = 5;
            long value = 0;

            Assert.IsFalse(value.Between(start, end, true));
            Assert.IsFalse(value.Between(start, end));
        }

        [TestMethod]
        public void Exclusive_Value_Equals_Start_Returns_False()
        {
            long start = 1;
            long end = 5;
            long value = 1;

            Assert.IsFalse(value.Between(start, end, false));
        }

        [TestMethod]
        public void Exclusive_Value_Equals_End_Returns_False()
        {
            long start = 1;
            long end = 5;
            long value = 5;

            Assert.IsFalse(value.Between(start, end, false));
        }
    }
}
