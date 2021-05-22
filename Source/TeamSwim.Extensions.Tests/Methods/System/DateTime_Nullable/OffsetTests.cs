using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemDateTime.Tests
{
    [TestClass]
    public class NullableOffsetTests : BaseUnitTest
    {
        internal const string ToDateTimeOffsetTest = "DateTime.ToDateTimeOffset()";

        [TestMethod]
        public void DateTimeOffset_Is_Returned_When_Value_Not_Null()
        {
            DateTime? dt =Utility.RandomDateTime();

            var utc = dt.Offset();

            Assert.AreEqual(typeof(DateTimeOffset), utc.GetType());
        }

        [TestMethod]
        public void Nothing_Is_Returned_When_Value_Null()
        {
            DateTime? dt = null;

            var utc = dt.Offset();

            Assert.IsNull(utc);
        }
    }
}
