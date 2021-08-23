using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class ExceptTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            List<int> source = null;
            Func<int, bool> predicate = _ => true;

            var actual = source.Except(predicate).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Predicate_Throws_Exception()
        {
            var source = new List<int> {1, 2, 3, 4};
            Func<int, bool> predicate = null;

            var actual = source.Except(predicate).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Expected_Values()
        {
            var source = new List<int> { 1, 2, 3, 4 };
            
            var actual = source.Except(i => i == 1 || i == 2 || i == 3).ToList();
            
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(4, actual.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception_With_Ordinal()
        {
            List<int> source = null;
            Func<int, int, bool> predicate = (_, __) => true;

            var actual = source.Except(predicate).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Predicate_Throws_Exception_With_Ordinal()
        {
            var source = new List<int> { 1, 2, 3, 4 };
            Func<int, int, bool> predicate = null;

            var actual = source.Except(predicate).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Expected_Values_With_Ordinal()
        {
            var source = new List<int> { 1, 2, 3, 4 };

            var actual = source.Except((i, idx) => idx == 1).ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(1, actual.ElementAt(0));
            Assert.AreEqual(3, actual.ElementAt(1));
            Assert.AreEqual(4, actual.ElementAt(2));
        }
    }
}
