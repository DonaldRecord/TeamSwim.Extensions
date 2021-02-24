using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class ToReadOnlyListTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Throws_Exception()
        {
            IEnumerable<string> source = null;
            var actual = source.ToReadOnlyList();
            Assert.Fail();
        }

        [TestMethod]
        public void Returns_Same_Instance_When_Implementing_Read_Only_List()
        {
            var source = new List<int> {1, 2, 3};
            var actual = source.ToReadOnlyList();
            Assert.ReferenceEquals(source, actual);
        }

        [TestMethod]
        public void Returns_New_Instance_When_Not_Read_Only_List()
        {
            IEnumerable<int> TestSequence()
            {
                yield return 1;
                yield return 2;
                yield return 3;
            }

            var source = TestSequence();
            var actual = source.ToReadOnlyList();
            Assert.IsTrue(((IList<int>)actual).IsReadOnly);
        }
    }
}
