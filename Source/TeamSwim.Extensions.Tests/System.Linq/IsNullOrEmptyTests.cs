using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class IsNullOrEmptyTests
    {
        [TestMethod]
        public void Null_Source_Returns_True()
        {
            var result = new Scope {Source = null}.ExecuteTest();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Empty_Source_Returns_True()
        {
            var result = new Scope {Source = new List<string>()}.ExecuteTest();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Source_With_Elements_Returns_False()
        {
            var result = new Scope().ExecuteTest();

            Assert.IsFalse(result);
        }

        class Scope
        {
            public List<string> Source { get; set; } = new List<string>
            {
                Utility.RandomString(),
                Utility.RandomString(),
                Utility.RandomString()
            };

            public bool ExecuteTest() => Source.IsNullOrEmpty();
        }
    }
}
