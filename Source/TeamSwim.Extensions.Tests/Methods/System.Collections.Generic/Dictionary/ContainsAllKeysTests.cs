using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Collections.Generic.Dictionary
{
    [TestClass]
    public class ContainsAllKeysTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Null_Dictionary_Throws()
        {
            Dictionary<string, object> uut = null;
            var actual = uut.ContainsAllKeys();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Argument_Throws()
        {
            var uut = GetInstance("1", "2", "3");
            IEnumerable<string> arg = null;
            var actual = uut.ContainsAllKeys(arg);
            Assert.Fail();
        }

        [TestMethod]
        public void Empty_Argument_Behavior()
        {
            var uut = GetInstance("1", "2", "3");
            var actual = uut.ContainsAllKeys();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Returns_Expected_True()
        {
            var uut = GetInstance("1", "2", "3");
            var actual = uut.ContainsAllKeys("1", "2", "3");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Returns_Expected_False()
        {
            var uut = GetInstance("1", "2", "3");
            var actual = uut.ContainsAllKeys("1", "2", "4");
            Assert.IsFalse(actual);
        }

        private Dictionary<string, object> GetInstance(params string[] keys)
        {
            var result = new Dictionary<string, object>();
            foreach (var key in keys)
                result[key] = new object();
            return result;
        }
    }
}
