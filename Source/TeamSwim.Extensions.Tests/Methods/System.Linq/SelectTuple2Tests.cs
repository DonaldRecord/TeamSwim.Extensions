using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class SelectTuple2Tests
    {
        // FIRST OVERLOAD

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            List<int> source = null;

            var actual = source.SelectTuple(i => i, i => i.ToString()).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Func1_Throws_Exception()
        {
            List<int> source = new List<int> {1, 2, 3};
            Func<int, string> func1 = null;
            Func<int, string> func2 = i => i.ToString();

            var actual = source.SelectTuple(func1, func2).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Func2_Throws_Exception()
        {
            List<int> source = new List<int> { 1, 2, 3 };
            Func<int, string> func1 = i => i.ToString();
            Func<int, string> func2 = null;

            var actual = source.SelectTuple(func1, func2).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Expected_Results()
        {
            var source = new List<int> {1, 2, 3};
            
            var actual = source.SelectTuple(i => i, i => i.ToString()).ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(1, actual.ElementAt(0).Item1);
            Assert.AreEqual("1", actual.ElementAt(0).Item2);
        }

        // SECOND OVERLOAD

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception_2()
        {
            List<int> source = null;

            var actual = source.SelectTuple(i => i, (i, item1) => i.ToString()).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Func1_Throws_Exception_2()
        {
            List<int> source = new List<int> { 1, 2, 3 };
            Func<int, string> func1 = null;
            Func<int, string, string> func2 = (i, item1) => item1.ToString();

            var actual = source.SelectTuple(func1, func2).ToList();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Func2_Throws_Exception_2()
        {
            List<int> source = new List<int> { 1, 2, 3 };
            Func<int, string> func1 = i => i.ToString();
            Func<int, string, string> func2 = null;

            var actual = source.SelectTuple(func1, func2).ToList();
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Expected_Results_2()
        {
            var source = new List<int> { 1, 2, 3 };

            var actual = source.SelectTuple(i => i, (i, item1) => item1.ToString()).ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(1, actual.ElementAt(0).Item1);
            Assert.AreEqual("1", actual.ElementAt(0).Item2);
        }
    }
}
