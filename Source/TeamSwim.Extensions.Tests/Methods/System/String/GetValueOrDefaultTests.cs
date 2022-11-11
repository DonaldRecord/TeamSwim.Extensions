using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class GetValueOrDefaultTests
    {
        [TestMethod]
        public void Empty_Only_Expected_Replace()
        {
            var value = "value";

            Assert.AreEqual(value, ((string)null).GetValueOrDefault(value, false));
            Assert.AreEqual(value, "".GetValueOrDefault(value, false));
        }

        [TestMethod]
        public void Empty_Only_Expected_Same_Value()
        {
            var value = "value";

            Assert.AreNotEqual(value, "adv".GetValueOrDefault(value, false));
            Assert.AreNotEqual(value, "   ".GetValueOrDefault(value, false));
        }

        [TestMethod]
        public void Whitespace_Expected_Replace()
        {
            var value = "value";

            Assert.AreEqual(value, ((string)null).GetValueOrDefault(value));
            Assert.AreEqual(value, "".GetValueOrDefault(value));
            Assert.AreEqual(value, "   ".GetValueOrDefault(value));
        }

        [TestMethod]
        public void Whitespace_Expected_Same_Value()
        {
            var value = "value";

            Assert.AreNotEqual(value, "adv".GetValueOrDefault(value));
            Assert.AreNotEqual(value, "   cc   ".GetValueOrDefault(value));
        }

        [TestMethod]
        public void Null_Replacement_Is_Possible()
        {
            Assert.IsNull(String.Empty.GetValueOrDefault(null, false));
            Assert.IsNull(String.Empty.GetValueOrDefault(null));
            Assert.IsNotNull("       ".GetValueOrDefault(null, false));
            Assert.IsNull("          ".GetValueOrDefault(null));
        }
    }
}
