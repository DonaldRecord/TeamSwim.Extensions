using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class PartitionTests
    {
        [TestMethod]
        public void Throws_Expected_Exceptions()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ((List<int>)null).Partition(1).ToList());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new List<int> {1, 2, 3}.Partition(0).ToList());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new List<int> {1, 2, 3}.Partition(-1).ToList());
        }

        [TestMethod]
        public void Returns_Expected_Equal_Partitions()
        {
            var source = Enumerable.Range(1, 20);
            var actual = source.Partition(5).ToList();

            Assert.AreEqual(4, actual.Count);
            Assert.AreEqual(5, actual[0].Count);
            Assert.AreEqual(5, actual[1].Count);
            Assert.AreEqual(5, actual[2].Count);
            Assert.AreEqual(5, actual[3].Count);
        }

        [TestMethod]
        public void Returns_Expected_Equal_Single_Partition()
        {
            var source = Enumerable.Range(1, 5);
            var actual = source.Partition(5).ToList();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(5, actual[0].Count);
        }

        [TestMethod]
        public void Returns_Expected_Single_Partition_For_Smaller_Size()
        {
            var source = Enumerable.Range(1, 7);
            var actual = source.Partition(10).ToList();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(7, actual[0].Count);
        }

        [TestMethod]
        public void Returns_Expected_Multiple_Partitions_With_Remainder()
        {
            var source = Enumerable.Range(1, 17);
            var actual = source.Partition(10).ToList();

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(10, actual[0].Count);
            Assert.AreEqual(7, actual[1].Count);
        }
    }
}
