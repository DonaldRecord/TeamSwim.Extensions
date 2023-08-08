using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class OrEmptyTests
    {
        [TestMethod]
        public void Not_Empty_Source_Returns_Expected_Results()
        {
            var source = new List<int> { 1, 2, 3 };
            var result = source.OrEmpty();

            Assert.AreSame(source, result);
        }

        [TestMethod]
        public void Empty_Source_Returns_Expected_Results()
        {
            var source = new List<int>();
            var result = source.OrEmpty();

            Assert.AreSame(source, result);
        }

        [TestMethod]
        public void Null_Source_Returns_Expected_Results()
        {
            List<int> source = null;
            var result = source.OrEmpty();

            Assert.IsNull(source);
            Assert.IsNotNull(result);
        }
    }
}
