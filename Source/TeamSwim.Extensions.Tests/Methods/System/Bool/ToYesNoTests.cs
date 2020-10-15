using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.System.Bool
{
    [TestClass]
    public class ToYesNoTests : BaseUnitTest
    {
        [TestMethod]
        public void Lowercase_Options_Return_Correctly()
        {
            Assert.AreEqual("yes", true.ToYesNo());
            Assert.AreEqual("no", false.ToYesNo());
            Assert.AreEqual("yes", true.ToYesNo(ToYesNoOptions.Lowercase));
            Assert.AreEqual("no", false.ToYesNo(ToYesNoOptions.Lowercase));
        }

        [TestMethod]
        public void Uppercase_Options_Return_Correctly()
        {
            Assert.AreEqual("YES", true.ToYesNo(ToYesNoOptions.Uppercase));
            Assert.AreEqual("NO", false.ToYesNo(ToYesNoOptions.Uppercase));
        }

        [TestMethod]
        public void Capital_Options_Return_Correctly()
        {
            Assert.AreEqual("Yes", true.ToYesNo(ToYesNoOptions.Capital));
            Assert.AreEqual("No", false.ToYesNo(ToYesNoOptions.Capital));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Default_Throws_Exception()
        {
            Assert.IsFalse(Enum.IsDefined(typeof(ToYesNoOptions), Int32.MaxValue));
            true.ToYesNo((ToYesNoOptions)Int32.MaxValue);
            Assert.Fail();
        }
    }
}
