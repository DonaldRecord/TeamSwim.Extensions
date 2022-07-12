using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class AsLocalTests
    {
        [TestMethod]
        public void Utc_Date_Converts_To_Local()
        {
            var dt = DateTime.UtcNow;
            Assert.AreEqual(DateTimeKind.Utc, dt.Kind);

            var uut = dt.AsLocal();

            Assert.AreEqual(DateTimeKind.Local, uut.Kind);
        }

        [TestMethod]
        public void Unspecified_Date_Converts_To_Local()
        {
            var dt = new DateTime();
            Assert.AreEqual(DateTimeKind.Unspecified, dt.Kind);

            var uut = dt.AsLocal();

            Assert.AreEqual(DateTimeKind.Local, uut.Kind);
        }

        [TestMethod]
        public void Local_Date_Unaffected()
        {
            var dt = DateTime.Now;
            Assert.AreEqual(DateTimeKind.Local, dt.Kind);

            var uut = dt.AsLocal();

            Assert.AreEqual(DateTimeKind.Local, uut.Kind);
        }
    }
}
