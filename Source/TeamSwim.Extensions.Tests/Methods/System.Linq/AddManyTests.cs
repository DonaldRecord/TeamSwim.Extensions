using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class AddManyTests : BaseUnitTest
    {
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
    }
}
