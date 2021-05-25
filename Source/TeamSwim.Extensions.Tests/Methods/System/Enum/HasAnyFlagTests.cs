using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using E = TeamSwim.Extensions.SystemEnum.Tests.HasAllFlagsTestScope.TestEnum;

namespace TeamSwim.Extensions.SystemEnum.Tests
{
    [TestClass]
    public class HasAnyFlagTests : BaseUnitTest
    {
        internal const string HasAnyFlagTest = "Enum.HasAnyFlag()";

        [TestMethod]
        public void Included_Flag_Returns_True()
        {
            var value = E.One | E.Two | E.Four;
            var retVal = value.HasAnyFlag(E.Four, E.Eight);

            Assert.IsTrue(retVal);
        }

        [TestMethod]
        public void Missing_Flag_Returns_False()
        {
            var value = E.One | E.Two;
            var retVal = value.HasAnyFlag(E.Four, E.Eight);

            Assert.IsFalse(retVal);
        }
    }

    public class HasAnyFlagTestScope
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