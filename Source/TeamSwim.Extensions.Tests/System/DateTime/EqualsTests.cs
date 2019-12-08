using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.System.DateTimeExtensions
{
    [TestClass]
    public class EqualsTests : BaseUnitTest
    {
        internal const string EqualTest = "DateTime.Equals()";
        
        [TestMethod]
        public void Inclusive_Equal_Timespan_Returns_True()
        {
            var a =Utility.RandomDateTime();
            var b = a.AddDays(1);

            var diff = TimeSpan.FromDays(1);

            var retVal = a.Equals(b, diff, true);

            Assert.IsTrue(retVal);
        }

        [TestMethod]
        public void Exclusive_Smaller_Timespan_Returns_False()
        {
            var a =Utility.RandomDateTime();
            var b = a.AddDays(1);

            var diff = TimeSpan.FromSeconds(2);

            var retVal = a.Equals(b, diff, false);

            Assert.IsFalse(retVal);
        }
    }
}
