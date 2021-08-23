using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class AppendIfTests
    {
        [TestMethod]
        public void Flag_True_Appends_Expected_Element()
        {
            var source = new List<int> {1};
            source = source.AppendIf(true, 2).ToList();

            Assert.AreEqual(2, source.Count);
            Assert.AreEqual(2, source.ElementAt(1));
        }

        [TestMethod]
        public void Flag_False_Does_Not_Append_Expected_Element()
        {
            var source = new List<int> {1};
            source = source.AppendIf(false, 2).ToList();

            Assert.AreEqual(1, source.Count);
        }
    }
}
