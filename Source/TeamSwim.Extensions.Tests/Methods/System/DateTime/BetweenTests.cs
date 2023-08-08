using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemDateTime.Tests
{
    [TestClass]
    public partial class BetweenTests : BaseUnitTest
    {
        [TestMethod]
        public void Char_Between_Inclusive_Value_Equals_Start_Returns_True()
        {
            var start = Utility.RandomDateTime();
            var end = start.AddDays(2);
            var value = start;

            Assert.IsTrue(value.Between(start, end, true));
            Assert.IsTrue(value.Between(start, end));
        }

        [TestMethod]
        public void Char_Between_Method_Inclusive_Value_Equals_End_Returns_True()
        {
            var start = Utility.RandomDateTime();
            var end = start.AddDays(2);
            var value = end;

            Assert.IsTrue(value.Between(start, end, true));
            Assert.IsTrue(value.Between(start, end));
        }

        [TestMethod]
        public void Inclusive_Value_Not_Between_Start_And_End_Returns_False()
        {
            var start = Utility.RandomDateTime();
            var end = start.AddDays(2);
            var value = start.AddDays(-1);

            Assert.IsFalse(value.Between(start, end, true));
            Assert.IsFalse(value.Between(start, end));
        }

        [TestMethod]
        public void Char_Between_Method_Exclusive_Value_Equals_Start_Returns_False()
        {
            var start = Utility.RandomDateTime();
            var end = start.AddDays(2);
            var value = start;

            Assert.IsFalse(value.Between(start, end, false));
        }

        [TestMethod]
        public void Char_Between_Method_Exclusive_Value_Equals_End_Returns_False()
        {
            var start = Utility.RandomDateTime();
            var end = start.AddDays(2);
            var value = end;

            Assert.IsFalse(value.Between(start, end, false));
        }
    }
}
