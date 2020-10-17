using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Threading.Tasks
{
    [TestClass]
    public class AsTaskTests
    {
        [TestMethod]
        public async Task Returns_Expected_Value()
        {
            string str = Utility.RandomString();

            var actual = str.AsTask();
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Task<string>));
            Assert.AreEqual(str, await actual);
        }

        [TestMethod]
        public async Task Returns_Expected_Null()
        {
            string str = null;
            
            var actual = str.AsTask();
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Task<string>));
            Assert.IsNull(await actual);
        }
    }
}
