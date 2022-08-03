using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class NullableDateTimeAsLocalTests
    {
        [TestMethod]
        public void Utc_Date_Converts_To_Local()
        {
            DateTime? dt = DateTime.UtcNow;
            Assert.AreEqual(DateTimeKind.Utc, dt.Value.Kind);

            var uut = dt.AsLocal();

            Assert.AreEqual(DateTimeKind.Local, uut.Value.Kind);
        }

        [TestMethod]
        public void Unspecified_Date_Converts_To_Local()
        {
            DateTime? dt = new DateTime();
            Assert.AreEqual(DateTimeKind.Unspecified, dt.Value.Kind);

            var uut = dt.AsLocal();

            Assert.AreEqual(DateTimeKind.Local, uut.Value.Kind);
        }

        [TestMethod]
        public void Local_Date_Unaffected()
        {
            DateTime? dt = DateTime.Now;
            Assert.AreEqual(DateTimeKind.Local, dt.Value.Kind);

            var uut = dt.AsLocal();

            Assert.AreEqual(DateTimeKind.Local, uut.Value.Kind);
        }

        [TestMethod]
        public void Null_Data_Returns_Null()
        {
            DateTime? dt = null;
            var uut = dt.AsLocal();
            Assert.IsNull(uut);
        }
    }
}