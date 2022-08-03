using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Generic
{
    [TestClass]
    public class ToDictionaryTests
    {
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
    }
}
