using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class AssertDistinctTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Argument_Null_Exception()
        {
            List<int> uut = null;
            var actual = uut.AssertDistinct().ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Throws_Expected_Default_Exception_With_Default_Comparer()
        {
            var uut = new List<int> {1, 1};
            var actual = uut.AssertDistinct().ToList();
            Assert.Fail();
        }

        [TestMethod] [ExpectedException(typeof(NotSupportedException))]
        public void Throws_Expected_Custom_Exception_With_Default_Comparer()
        {
            var uut = new List<int> {1, 1};
            var actual = uut.AssertDistinct(exception: new NotSupportedException()).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Throws_Expected_Default_Exception_With_Custom_Comparer()
        {
            var uut = new List<string> {"a", "A"};
            var actual = uut.AssertDistinct(StringComparer.OrdinalIgnoreCase).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Throws_Expected_Custom_Exception_With_Custom_Comparer()
        {
            var uut = new List<string> { "a", "A" };
            var actual = uut.AssertDistinct(StringComparer.OrdinalIgnoreCase, new NotSupportedException()).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Expected_Success_With_Default_Comparer()
        {
            var uut = new List<int> {1, 2, 3};
            var actual = uut.AssertDistinct().ToList();
        }

        [TestMethod]
        public void Expected_Success_With_Custom_Comparer()
        {
            var uut = new List<string> {"a", "b", "c"};
            var actual = uut.AssertDistinct(StringComparer.OrdinalIgnoreCase).ToList();
        }
    }
}
