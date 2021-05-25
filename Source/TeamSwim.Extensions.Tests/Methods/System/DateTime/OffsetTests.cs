using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemDateTime.Tests
{
    [TestClass]
    public class OffsetTests : BaseUnitTest
    {
        [TestMethod]
        public void Date_Time_Offset_Is_Returned()
        {
            var dt = Utility.RandomDateTime();

            var utc = dt.Offset();

            Assert.IsInstanceOfType(utc, typeof(DateTimeOffset));
        }
    }
}
