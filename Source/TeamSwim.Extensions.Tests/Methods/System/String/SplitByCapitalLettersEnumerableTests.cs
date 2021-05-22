using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemString.Tests
{
    [TestClass]
    public class SplitByCapitalLettersEnumerableTests
    {
        [TestMethod]
        public void No_Capital_Letters_Returns_Single_Element_Collection()
        {
            var result = "nocapitalletters".SplitByCapitalLettersEnumerable();
            Assert.IsInstanceOfType(result, typeof(IEnumerable<string>));
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void String_With_Capital_Letters_Returns_Expected_Elements()
        {
            var result = "NoCapital Letters".SplitByCapitalLettersEnumerable().ToList();
            Assert.IsInstanceOfType(result, typeof(IEnumerable<string>));
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("No", result.ElementAt(0));
            Assert.AreEqual("Capital ", result.ElementAt(1));
            Assert.AreEqual("Letters", result.ElementAt(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Value_Throws_Argument_Null_Exception()
        {
            string str = null;
            var result = str.SplitByCapitalLettersEnumerable().ToList();
            Assert.Fail();
        }
    }
}
