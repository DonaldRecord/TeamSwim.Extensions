using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.IO
{
    [TestClass]
    public class GetLastPathSegmentTests
    {
        [TestMethod]
        public void Throws_Expected_Exceptions()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ((string)null).GetLastPathSegment());
            Assert.ThrowsException<ArgumentException>(() => String.Empty.GetLastPathSegment());
        }

        [TestMethod]
        public void Returns_Expected_Values()
        {
            void AssertValue(string value, string expected) => Assert.AreEqual(expected, value.GetLastPathSegment());

            AssertValue(@"a\b\c\d\e", "e");
            AssertValue("e", "e");
        }
    }
}
