using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.System.Char
{
    [TestClass]
    public partial class BetweenTests : BaseUnitTest
    {
        [TestMethod]
        public void Char_Between_Inclusive_Value_Equals_Start_Returns_True()
        {
            char start = '1';
            char end = '5';
            char value = '1';

            Assert.IsTrue(value.Between(start, end, true));
            Assert.IsTrue(value.Between(start, end));
        }

        [TestMethod]
        public void Char_Between_Method_Inclusive_Value_Equals_End_Returns_True()
        {
            char start = '1';
            char end = '5';
            char value = '5';

            Assert.IsTrue(value.Between(start, end, true));
            Assert.IsTrue(value.Between(start, end));
        }

        [TestMethod]
        public void Inclusive_Value_Not_Between_Start_And_End_Returns_False()
        {
            char start = '1';
            char end = '5';
            char value = '0';

            Assert.IsFalse(value.Between(start, end, true));
            Assert.IsFalse(value.Between(start, end));
        }

        [TestMethod]
        public void Char_Between_Method_Exclusive_Value_Equals_Start_Returns_False()
        {
            char start = '1';
            char end = '5';
            char value = '1';

            Assert.IsFalse(value.Between(start, end, false));
        }

        [TestMethod]
        public void Char_Between_Method_Exclusive_Value_Equals_End_Returns_False()
        {
            char start = '1';
            char end = '5';
            char value = '5';

            Assert.IsFalse(value.Between(start, end, false));
        }
    }
}
