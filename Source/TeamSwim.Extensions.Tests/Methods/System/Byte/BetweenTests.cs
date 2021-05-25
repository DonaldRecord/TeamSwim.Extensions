using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemByte.Tests
{
    [TestClass]
    public class BetweenTests : BaseUnitTest
    {
        [TestMethod]
        public void Inclusive_Value_Equals_Start_Returns_True()
        {
            byte start = 1;
            byte end = 5;
            byte value = 1;

            Assert.IsTrue(value.Between(start, end, true));
            Assert.IsTrue(value.Between(start, end));
        }

        [TestMethod]
        public void Inclusive_Value_Equals_End_Returns_True()
        {
            byte start = 1;
            byte end = 5;
            byte value = 5;

            Assert.IsTrue(value.Between(start, end, true));
            Assert.IsTrue(value.Between(start, end));
        }

        [TestMethod]
        public void Inclusive_Value_Not_Between_Start_And_End_Returns_False()
        {
            byte start = 1;
            byte end = 5;
            byte value = 0;

            Assert.IsFalse(value.Between(start, end, true));
            Assert.IsFalse(value.Between(start, end));
        }

        [TestMethod]
        public void Exclusive_Value_Equals_Start_Returns_False()
        {
            byte start = 1;
            byte end = 5;
            byte value = 1;

            Assert.IsFalse(value.Between(start, end, false));
        }

        [TestMethod]
        public void Exclusive_Value_Equals_End_Returns_False()
        {
            byte start = 1;
            byte end = 5;
            byte value = 5;

            Assert.IsFalse(value.Between(start, end, false));
        }
    }
}
