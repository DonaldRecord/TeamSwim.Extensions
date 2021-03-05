using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Methods.System.Linq.Tests
{
    [TestClass]
    public class CrossJoinTests
    {
        [TestMethod]
        public void Cross_Join_Returns_Expected_Results_Same_Type()
        {
            var source = new List<string> {"1", "2", "3"};
            var cross = new List<string> {"4", "5", "6"};

            var results = source.CrossJoin(cross, String.Concat).ToList();

            Assert.AreEqual(9, results.Count);
            Assert.AreEqual("14", results.ElementAt(0));
            Assert.AreEqual("15", results.ElementAt(1));
            Assert.AreEqual("16", results.ElementAt(2));
            Assert.AreEqual("24", results.ElementAt(3));
            Assert.AreEqual("25", results.ElementAt(4));
            Assert.AreEqual("26", results.ElementAt(5));
            Assert.AreEqual("34", results.ElementAt(6));
            Assert.AreEqual("35", results.ElementAt(7));
            Assert.AreEqual("36", results.ElementAt(8));
        }

        [TestMethod]
        public void Cross_Join_Returns_Nothing_When_Cross_Is_Empty_And_No_Fallback()
        {
            var source = new List<string> { "1", "2", "3" };
            var cross = new List<string>();

            var results = source.CrossJoin(cross, String.Concat).ToList();

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Cross_Join_Returns_Source_When_Cross_Is_Empty_And_Fallback()
        {
            var source = new List<string> { "1", "2", "3" };
            var cross = new List<string>();

            var results = source.CrossJoin(cross, String.Concat, s => s).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("1", results.ElementAt(0));
            Assert.AreEqual("2", results.ElementAt(1));
            Assert.AreEqual("3", results.ElementAt(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cross_Join_Throws_For_Null_Source()
        {
            IEnumerable<string> source = null;
            var cross = new List<string> { "4", "5", "6" };

            var results = source.CrossJoin(cross, String.Concat).ToList();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cross_Join_Throws_For_Null_Collection()
        {
            var source = new List<string> {"1", "2", "3"};
            ICollection<string> cross = null;

            var results = source.CrossJoin(cross, String.Concat).ToList();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cross_Join_Throws_For_Null_Callback()
        {
            var source = new List<string> { "1", "2", "3" };
            var cross = new List<string> { "4", "5", "6" };
            Func<string, string, string> callback = null;

            var results = source.CrossJoin(cross, callback).ToList();

            Assert.Fail();
        }
    }
}
