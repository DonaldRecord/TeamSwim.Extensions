using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.System.DateTime_Nullable
{
    [TestClass]
    public class TryParseTests : BaseUnitTest
    {
        internal const string TryParseTest = "DateTime?.Offset()";

        [TestMethod]
        public void Try_Parse_Returns_Null_And_False_When_String_Is_Null()
        {
            DateTime? dt;
            var parsed = DateTimeExt.TryParse(null, out dt);

            Assert.IsTrue(parsed);
            Assert.IsNull(dt);
        }

        [TestMethod]
        public void Try_Parse_Returns_Null_And_False_When_String_Is_Not_Date()
        {
            DateTime? dt;
            var parsed = DateTimeExt.TryParse("NOT A DATE", out dt);

            Assert.IsFalse(parsed);
            Assert.IsNull(dt);
        }

        [TestMethod]
        public void Try_Parse_Returns_Value_And_True_When_String_Is_Date()
        {
            var expected = RandomDateTime();

            DateTime? dt;
            var parsed = DateTimeExt.TryParse(expected.ToString(), out dt);

            Assert.IsTrue(parsed);
            Assert.IsNotNull(dt);
            Assert.AreEqual(expected, dt.Value);
        }
    }
}
