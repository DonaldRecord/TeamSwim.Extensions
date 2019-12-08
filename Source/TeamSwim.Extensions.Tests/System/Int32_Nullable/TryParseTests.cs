using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.SystemTests
{
    [TestClass]
    public class TryParseTests : BaseUnitTest
    {
        private const string TryParseTest = "Int32?.TryParse()";

        [TestMethod]
        public void Null_String_Returns_Null()
        {
            string s = null;

            int? i;

            var result = NullableInt32Ext.TryParse(s, out i);

            Assert.IsTrue(result);
            Assert.IsNull(i);
        }

        [TestMethod]
        public void Parsable_String_Returns_Nullable_Int32()
        {
            var s = RandomString(maxLength: 4);

            int? i;

            var result = NullableInt32Ext.TryParse(s, out i);

            Assert.IsTrue(result);
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void Unparsable_String_Returns_Null()
        {
            var s = RandomString();

            int? i;

            var result = NullableInt32Ext.TryParse(s, out i);

            Assert.IsFalse(result);
            Assert.IsNull(i);
        }
    }
}
