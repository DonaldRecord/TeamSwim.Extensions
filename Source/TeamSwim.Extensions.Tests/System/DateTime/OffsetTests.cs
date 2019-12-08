using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.System.DateTimeExtensions
{
    [TestClass]
    public class OffsetTests : BaseUnitTest
    {
        internal const string OffsetTest = "DateTime.Offset()";

        [TestMethod]
        public void Date_Time_Offset_Is_Returned()
        {
            var dt = RandomDateTime();

            var utc = dt.Offset();

            Assert.AreEqual(typeof(DateTimeOffset), utc.GetType());
        }
    }
}
