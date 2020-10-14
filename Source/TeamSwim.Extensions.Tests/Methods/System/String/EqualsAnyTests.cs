using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.SystemTests
{
    [TestClass]
    public class EqualsAnyTests : BaseUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Null_Instance_Throws_Exception()
        {
            string str = null;
            var actual = str.EqualsAny(StringComparison.OrdinalIgnoreCase, "A", "B", "C");
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Expected_True()
        {
            var actual = "a".EqualsAny(StringComparison.OrdinalIgnoreCase, "A", "B", "C");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Returns_Expected_False()
        {
            var actual = "d".EqualsAny(StringComparison.OrdinalIgnoreCase, "A", "B", "C");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Can_Handle_Null_Argument_In_Array()
        {
            var actual = "a".EqualsAny(StringComparison.OrdinalIgnoreCase, "A", "B", null, "C");
            Assert.IsTrue(actual);
        }

    }
}
