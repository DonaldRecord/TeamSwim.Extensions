using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using E = TeamSwim.Extensions.SystemEnum.Tests.HasAllFlagsTestScope.TestEnum;

namespace TeamSwim.Extensions.SystemEnum.Tests

{
    [TestClass]
    public class HasAllFlagsTests : BaseUnitTest
    {
        internal const string HasAllFlagsTest = "Enum.HasAllFlags()";

        [TestMethod]
        public void All_Flags_Returns_True()
        {
            var value = E.One | E.Two | E.Four;
            var retVal = value.HasAllFlags(E.One, E.Two, E.Four);

            Assert.IsTrue(retVal);
        }

        [TestMethod]
        public void Missing_Flags_Returns_False()
        {
            var value = E.One | E.Two | E.Four;
            var retVal = value.HasAllFlags(E.One, E.Two, E.Four, E.Eight);

            Assert.IsFalse(retVal);
        }
    }

    public class HasAllFlagsTestScope
    {
        [Flags]
        public enum TestEnum
        {
            One = 1,
            Two = 2,
            Four = 4,
            Eight = 8
        }
    }
}
