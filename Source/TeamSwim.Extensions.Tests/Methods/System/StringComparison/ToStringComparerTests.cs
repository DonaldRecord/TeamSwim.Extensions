using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemStringComparison.Tests
{
    [TestClass]
    public class ToStringComparerTests : BaseUnitTest
    {
        [TestMethod]
        public void Current_Culture_Returned()
        {
            var actual = StringComparison.CurrentCulture.ToStringComparer();
            var expected = StringComparer.CurrentCulture;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Current_Culture_Ignore_Case_Returned()
        {
            var actual = StringComparison.CurrentCultureIgnoreCase.ToStringComparer();
            var expected = StringComparer.CurrentCultureIgnoreCase;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Invariant_Culture_Returned()
        {
            var actual = StringComparison.InvariantCulture.ToStringComparer();
            var expected = StringComparer.InvariantCulture;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Invariant_Culture_Ignore_Case_Returned()
        {
            var actual = StringComparison.InvariantCultureIgnoreCase.ToStringComparer();
            var expected = StringComparer.InvariantCultureIgnoreCase;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Ordinal_Returned()
        {
            var actual = StringComparison.Ordinal.ToStringComparer();
            var expected = StringComparer.Ordinal;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Ordinal_Ignore_Case_Returned()
        {
            var actual = StringComparison.OrdinalIgnoreCase.ToStringComparer();
            var expected = StringComparer.OrdinalIgnoreCase;

            Assert.AreEqual(actual, expected);
        }
    }
}
