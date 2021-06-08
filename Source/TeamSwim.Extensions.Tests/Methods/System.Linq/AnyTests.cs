using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Expected_Exceptions()
        {
            List<int> source = null;
            var actual = source.Any((i, idx) => idx == 1);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Predicate_Throws_Expected_Exceptions()
        {
            var source = new List<int>();
            Func<int, int, bool> predicate = null;
            var actual = source.Any(predicate);
            Assert.Fail();
        }

        [TestMethod]
        public void Any_Returns_Expected_Result()
        {
            var source = new List<int> {1, 2, 3, 4};
            var actual = source.Any((i, idx) => i == 4);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Any_Returns_Expected_Result_Based_On_Ordinal()
        {
            var source = new List<int> { 1, 2, 3, 4 };
            var actual = source.Any((i, idx) => idx == 4);
            Assert.IsFalse(actual);
        }
    }
}
