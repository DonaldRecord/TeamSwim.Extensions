using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.SystemTests
{
    [TestClass]
    public class NullEqualsTests : BaseUnitTest
    {
        internal const string NullEqualsTest = "Object.NullEquals()";

        [TestMethod]
        public void Both_Objects_Null_Returns_True()
        {
            object a = null;
            object b = null;

            var retVal = a.NullEquals(b);

            Assert.IsTrue(retVal);
        }

        [TestMethod]
        public void Assert_A_Is_Null_And_B_Is_Not_Null_Returns_False()
        {
            object a = null;
            object b = RandomString();

            var retVal = a.NullEquals(b);

            Assert.IsFalse(retVal);
        }

        [TestMethod]
        public void Assert_A_Is_Not_Null_And_B_Is_Null_Returns_False()
        {
            object a = RandomString();
            object b = null;

            var retVal = a.NullEquals(b);

            Assert.IsFalse(retVal);
        }

        [TestMethod]
        public void Assert_Equal_Objects_Returns_True()
        {
            object c = RandomString();
            object a = c;
            object b = c;

            var retVal = a.NullEquals(b);

            Assert.IsTrue(retVal);
        }

        [TestMethod]
        public void Assert_Different_Objects_Returns_False()
        {
            object c = RandomString();
            object d = RandomString();

            object a = c;
            object b = d;

            var retVal = a.NullEquals(b);

            Assert.IsFalse(retVal);
        }
    }
}
