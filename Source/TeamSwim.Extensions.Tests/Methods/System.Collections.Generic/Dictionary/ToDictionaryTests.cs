using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Generic
{
    [TestClass]
    public class ToDictionaryTests
    {
        [TestMethod]
        public void Throws_Expection_On_Null()
        {
            Dictionary<string, string> dict = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToDictionary());

            IEnumerable<IGrouping<int, string>> groups = null;
            Assert.ThrowsException<ArgumentNullException>(() => groups.ToDictionary());
        }
        
        [TestMethod]
        public void Returns_Expected_Value()
        {
            var seed = new Dictionary<string, string>
            {
                { 1.ToString(), 1.ToString() },
                { 2.ToString(), 2.ToString() },
                { 3.ToString(), 3.ToString() },
                { 4.ToString(), 4.ToString() },
            };

            var dict = new ReadOnlyDictionary<string, string>(seed);
            var actual = dict.ToDictionary();

            Assert.IsNotInstanceOfType(dict, typeof(Dictionary<string, string>));
            Assert.IsInstanceOfType(actual, typeof(Dictionary<string, string>));
            Assert.AreEqual(dict.Count, actual.Count);
            Assert.AreEqual(4, dict.Count);
        }

        [TestMethod]
        public void Returns_Expected_Group_Value()
        {
            var data = new[]
            {
                new GroupTest { Id = 1, Value = 1 },
                new GroupTest { Id = 1, Value = 2 },
                new GroupTest { Id = 1, Value = 3 },
                new GroupTest { Id = 1, Value = 4 },
                new GroupTest { Id = 2, Value = 2 },
                new GroupTest { Id = 2, Value = 3 },
                new GroupTest { Id = 2, Value = 4 },
                new GroupTest { Id = 3, Value = 3 },
                new GroupTest { Id = 3, Value = 4 },
                new GroupTest { Id = 4, Value = 4 },
            };

            var uut = data.GroupBy(g => g.Id).ToDictionary();

            Assert.AreEqual(uut[1].Count(), 4);
            Assert.AreEqual(uut[2].Count(), 3);
            Assert.AreEqual(uut[3].Count(), 2);
            Assert.AreEqual(uut[4].Count(), 1);
        }

        class GroupTest
        {
            public int Id { get; set; }
            public int Value { get; set; }
        }
    }
}
