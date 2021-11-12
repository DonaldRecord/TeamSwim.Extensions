using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class AddManyTests : BaseUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddMany_Null_Source_Throws_Exception()
        {
            ICollection<int?> source = null;
            var elements = new List<int?> { 1, null, null, 2, null, 3 };
            source.AddMany(elements);
            Assert.Fail();
        }

        [TestMethod]
        public void AddMany_Returns_Expected_List()
        {
            var list = new List<int?>();
            var elements = new List<int?> { 1, null, null, 2, null, 3 };
            list.AddMany(elements);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(null, list[1]);
            Assert.AreEqual(null, list[2]);
            Assert.AreEqual(2, list[3]);
            Assert.AreEqual(null, list[4]);
            Assert.AreEqual(3, list[5]);
        }

        [TestMethod]
        public void AddMany_Returns_Expected_List_With_Nullable()
        {
            var list = new List<int?>();
            var elements = new List<int?> { 1, null, null, 2, null, 3 };
            list.AddMany(elements, true);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        public void AddMany_Handles_Null_IEnumerable()
        {
            var uut = new List<int>();
            IEnumerable<int> arg = null;

            uut.AddMany(arg);

            Assert.AreEqual(0, uut.Count);
        }
    }
}
