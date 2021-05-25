using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemBoolean.Tests
{
    [TestClass]
    public class SwitchTests
    {
        [TestMethod]
        public void True_Returns_Expected_Result()
        {
            var uut = true;
            var actual = uut.Switch("yes", "no");
            Assert.AreEqual("yes", actual);
        }

        [TestMethod]
        public void False_Returns_Expected_Result()
        {
            var uut = false;
            var actual = uut.Switch("yes", "no");
            Assert.AreEqual("no", actual);
        }

        [TestMethod]
        public void Nullable_True_Returns_Expected_Result()
        {
            bool? uut = true;
            var actual = uut.Switch("yes", "no", "maybe");
            Assert.AreEqual("yes", actual);
        }

        [TestMethod]
        public void Nullable_False_Returns_Expected_Result()
        {
            bool? uut = false;
            var actual = uut.Switch("yes", "no", "maybe");
            Assert.AreEqual("no", actual);
        }

        [TestMethod]
        public void Nullable_Null_Returns_Expected_Result()
        {
            bool? uut = null;
            var actual = uut.Switch("yes", "no", "maybe");
            Assert.AreEqual("maybe", actual);
        }
    }
}
