using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
#pragma warning disable 618

namespace TeamSwim.Extensions.Tests.System.TypeTests
{
    [TestClass]
    public sealed class IsMarkedObsoleteTests : BaseUnitTest
    {
        internal const string IsMarkedObsoleteTest = "Type.IsMarkedObsolete";

        [TestMethod]
        public void Public_Obsolete_Type_Returns_True()
        {
            AssertObsoleteType(typeof(PublicObsoleteType), IsMarkedObsoleteTest);
        }

        [TestMethod]
        public void Public_Non_Obsolete_Type_Returns_True()
        {
            AssertNonObsoleteType(typeof(PublicNonObsoleteType));
        }

        [TestMethod]
        public void Internal_Obsolete_Type_Returns_True()
        {
            AssertObsoleteType(typeof(InternalObsoleteType), IsMarkedObsoleteTest);
        }

        [TestMethod]
        public void Internal_Non_Obsolete_Type_Returns_True()
        {
            AssertNonObsoleteType(typeof(InternalNonObsoleteType));
        }

        [TestMethod]
        public void Abstract_Obsolete_Type_Returns_True()
        {
            AssertObsoleteType(typeof(AbstractObsoleteType), IsMarkedObsoleteTest);
        }

        [TestMethod]
        public void Abstract_Non_Obsolete_Type_Returns_True()
        {
            AssertNonObsoleteType(typeof(AbstractNonObsoleteType));
        }

        [TestMethod]
        public void Private_Obsolete_Type_Returns_True()
        {
            AssertObsoleteType(typeof(PrivateObsoleteType), IsMarkedObsoleteTest);
        }

        [TestMethod]
        public void Private_Non_Obsolete_Type_Returns_True()
        {
            AssertNonObsoleteType(typeof(PrivateNonObsoleteType));
        }

        private void AssertObsoleteType(Type type, string expectedMessageValue)
        {
            Assert.IsNotNull(type);

            var attributeResult = type.IsMarkedObsolete(out ObsoleteAttribute attr);
            Assert.IsTrue(attributeResult);
            Assert.IsNotNull(attr);
            Assert.AreEqual(expectedMessageValue, attr.Message);

            var messageResult = type.IsMarkedObsolete(out string message);
            Assert.IsTrue(messageResult);
            Assert.IsNotNull(message);
            Assert.AreEqual(expectedMessageValue, message);
            Assert.AreEqual(attr.Message, message);

            var result = type.IsMarkedObsolete();
            Assert.IsTrue(result);
        }

        private void AssertNonObsoleteType(Type type)
        {
            Assert.IsNotNull(type);

            var attributeResult = type.IsMarkedObsolete(out ObsoleteAttribute attr);
            Assert.IsFalse(attributeResult);
            // ReSharper disable HeuristicUnreachableCode
            Assert.IsNull(attr);

            var messageResult = type.IsMarkedObsolete(out string message);
            Assert.IsFalse(messageResult);
            Assert.IsNull(message);

            var result = type.IsMarkedObsolete();
            Assert.IsFalse(result);
            // ReSharper restore HeuristicUnreachableCode
        }


        [Obsolete(IsMarkedObsoleteTest)]
        public class PublicObsoleteType { }
        public class PublicNonObsoleteType { }

        [Obsolete(IsMarkedObsoleteTest)]
        public class InternalObsoleteType { }
        public class InternalNonObsoleteType { }

        [Obsolete(IsMarkedObsoleteTest)]
        public abstract class AbstractObsoleteType { }
        public abstract class AbstractNonObsoleteType { }

        [Obsolete(IsMarkedObsoleteTest)]
        public abstract class PrivateObsoleteType { }
        public abstract class PrivateNonObsoleteType { }
    }
}
