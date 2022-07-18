using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public partial class AsUtcTests
    {
        [TestMethod]
        public void Utc_Date_Remains_The_Same()
        {
            var dt = DateTime.UtcNow;
            Assert.AreEqual(DateTimeKind.Utc, dt.Kind);

            var uut = dt.AsUtc();

            Assert.AreEqual(DateTimeKind.Utc, uut.Kind);
        }

        [TestMethod]
        public void Unspecified_Date_Converts_To_Utc()
        {
            var dt = new DateTime();
            Assert.AreEqual(DateTimeKind.Unspecified, dt.Kind);

            var uut = dt.AsUtc();

            Assert.AreEqual(DateTimeKind.Utc, uut.Kind);
        }

        [TestMethod]
        public void Local_Date_Converts_To_Utc()
        {
            var dt = DateTime.Now;
            Assert.AreEqual(DateTimeKind.Local, dt.Kind);

            var uut = dt.AsUtc();

            Assert.AreEqual(DateTimeKind.Utc, uut.Kind);
        }
    }
}