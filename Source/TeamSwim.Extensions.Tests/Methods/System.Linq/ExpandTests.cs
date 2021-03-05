using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class ExpandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Throws_Exception()
        {
            IEnumerable<int> source = null;
            var actual = source.Expand(s => s + 10).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Sequence_Returns_Expected_Results()
        {
            var source = new List<int> {1, 2, 3};
            var actual = source.Expand(i => i + 10, i => i + 20).ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(1, actual.ElementAt(0).ElementAt(0));
            Assert.AreEqual(11, actual.ElementAt(0).ElementAt(1));
            Assert.AreEqual(21, actual.ElementAt(0).ElementAt(2));
            Assert.AreEqual(2, actual.ElementAt(1).ElementAt(0));
            Assert.AreEqual(12, actual.ElementAt(1).ElementAt(1));
            Assert.AreEqual(22, actual.ElementAt(1).ElementAt(2));
            Assert.AreEqual(3, actual.ElementAt(2).ElementAt(0));
            Assert.AreEqual(13, actual.ElementAt(2).ElementAt(1));
            Assert.AreEqual(23, actual.ElementAt(2).ElementAt(2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Error_Not_Caught()
        {
            var source = new List<int> {1, 2, 3};
            Func<int, int> func = i =>
            {
                if (i % 2 == 0)
                    return i; 
                throw new InvalidOperationException();
            };

            var actual = source.Expand(func).ToList();
            var good = actual.ElementAt(1).ToList();
            var ex = actual.ElementAt(0).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Expand_Many_Null_Throws_Exception()
        {
            IEnumerable<int> source = null;
            var actual = source.ExpandMany(s => s + 10).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void ExpandMany_Sequence_Returns_Expected_Results()
        {
            var source = new List<int> {1, 2, 3};
            var actual = source.ExpandMany(i => i + 10, i => i + 20).ToList();

            Assert.AreEqual(9, actual.Count);
            Assert.AreEqual(1, actual.ElementAt(0));
            Assert.AreEqual(11, actual.ElementAt(1));
            Assert.AreEqual(21, actual.ElementAt(2));
            Assert.AreEqual(2, actual.ElementAt(3));
            Assert.AreEqual(12, actual.ElementAt(4));
            Assert.AreEqual(22, actual.ElementAt(5));
            Assert.AreEqual(3, actual.ElementAt(6));
            Assert.AreEqual(13, actual.ElementAt(7));
            Assert.AreEqual(23, actual.ElementAt(8));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExpandMany_Error_Not_Caught()
        {
            var source = new List<int> {1, 2, 3};
            Func<int, int> func = i =>
            {
                if (i % 2 == 0)
                    return i;
                throw new InvalidOperationException();
            };

            var actual = source.ExpandMany(func).ToList();
            Assert.Fail();
        }
    }
}
