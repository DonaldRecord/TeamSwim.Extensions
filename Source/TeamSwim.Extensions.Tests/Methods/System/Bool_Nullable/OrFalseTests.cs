using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.System.Bool_Nullable
{
    [TestClass]
    public class OrFalseTests : BaseUnitTest
    {
        [TestMethod]
        public void Null_Bool_Returns_False()
        {
            bool? value = null;

            var retVal = value.OrFalse();

            Assert.IsFalse(retVal);
        }

        [TestMethod]
        public void False_Bool_Returns_False()
        {
            bool? value = false;

            var retVal = value.OrFalse();

            Assert.IsFalse(retVal);
        }

        [TestMethod]
        public void True_Bool_Returns_True()
        {
            bool? value = true;

            var retVal = value.OrFalse();

            Assert.IsTrue(retVal);
        }
    }
}
