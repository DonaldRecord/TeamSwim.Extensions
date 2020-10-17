using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamSwim;

namespace System
{
    [TestClass]
    public class TeamSwimExtensionsTests
    {
        [TestMethod]
        public void Assembly_Returns_Expected_Value()
        {
            var expected = typeof(StringExt).Assembly;
            var actual = TeamSwimExtensions.Assembly;
            Assert.AreEqual(expected, actual);
        }
    }
}
