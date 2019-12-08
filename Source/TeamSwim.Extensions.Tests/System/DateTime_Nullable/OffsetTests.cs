using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.System.DateTimeNullableExtensions
{
    [TestClass]
    public class OffsetTests : BaseUnitTest
    {
        internal const string ToDateTimeOffsetTest = "DateTime.ToDateTimeOffset()";

        [TestMethod]
        public void DateTimeOffset_Is_Returned_When_Value_Not_Null()
        {
            DateTime? dt = RandomDateTime();

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
