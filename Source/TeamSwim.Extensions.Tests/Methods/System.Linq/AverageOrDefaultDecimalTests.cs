using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class AverageOrDefaultDecimalTests
    {
        List<decimal> TestList(params decimal[] decs) => new List<decimal>(decs);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_On_Null_Source()
        {
            List<decimal> list = null;
            var avg = list.AverageOrDefault(d => d);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Expected_Normal_Error_Behavior()
        {
            var avg = TestList().Average(d => d);
            Assert.Fail();
        }

        [TestMethod]
        public void Default_Empty_List_Behavior()
        {
            var avg1 = TestList().AverageOrDefault(d => d);
            Assert.AreEqual(0m, avg1);

            var avg2 = TestList().AverageOrDefault(d => d, 1.2m);
            Assert.AreEqual(1.2m, avg2);
        }

        [TestMethod]
        public void Expected_Average()
        {
            var list = TestList(1, 2, 4, 6, 7);
            var expected = list.Average(i => i);
            var actual = list.AverageOrDefault(i => i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Expected_Average_Overload()
        {
            var list = TestList(1, 2, 4, 6, 7).Cast<decimal>();
            var expected = list.Average();
            var actual = list.AverageOrDefault();
            Assert.AreEqual(expected, actual);
        }
    }
}
