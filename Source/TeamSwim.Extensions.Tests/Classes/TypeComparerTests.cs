using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Classes
{
    [TestClass]
    public class TypeComparerTests
    {
        [TestMethod]
        public void Non_Generic_Returns_Expected_True()
        {
            Assert.IsTrue(TypeComparer.Default.Equals(new TypeComparerTest1(), new TypeComparerTest1()));
            Assert.IsTrue(TypeComparer.Default.Equals(null, null));
        }

        [TestMethod]
        public void Generic_Returns_Expected_True()
        {
            Assert.IsTrue(TypeComparer.For<ITypeComparerTestInterface>().Equals(new TypeComparerTest1(), new TypeComparerTest1()));
            Assert.IsTrue(TypeComparer.For<ITypeComparerTestInterface>().Equals(null, null));
        }

        [TestMethod]
        public void Non_Generic_Returns_Matching_Hash_Codes()
        {
            Assert.AreEqual(
                TypeComparer.Default.GetHashCode(new TypeComparerTest1()),
                TypeComparer.Default.GetHashCode(new TypeComparerTest1()));
            Assert.AreEqual(
                TypeComparer.Default.GetHashCode(null),
                TypeComparer.Default.GetHashCode(null));
        }

        [TestMethod]
        public void Generic_Returns_Matching_Hash_Codes()
        {
            Assert.AreEqual(
                TypeComparer.For<ITypeComparerTestInterface>().GetHashCode(new TypeComparerTest1()),
                TypeComparer.For<ITypeComparerTestInterface>().GetHashCode(new TypeComparerTest1()));
            Assert.AreEqual(
                TypeComparer.For<ITypeComparerTestInterface>().GetHashCode(null),
                TypeComparer.For<ITypeComparerTestInterface>().GetHashCode(null));
        }

        [TestMethod]
        public void Non_Generic_Returns_Expected_False()
        {
            Assert.IsFalse(TypeComparer.Default.Equals(new TypeComparerTest1(), new TypeComparerTest2()));
            Assert.IsFalse(TypeComparer.Default.Equals(new TypeComparerTest1(), null));
            Assert.IsFalse(TypeComparer.Default.Equals(null, new TypeComparerTest2()));

            Assert.IsFalse(TypeComparer.Default.Equals(
                (ITypeComparerTestInterface) new TypeComparerTest1(), 
                (ITypeComparerTestInterface) new TypeComparerTest2()));
        }

        [TestMethod]
        public void Non_Generic_Returns_Different_Hash_Codes()
        {
            Assert.AreNotEqual(
                TypeComparer.Default.GetHashCode(new TypeComparerTest1()),
                TypeComparer.Default.GetHashCode(new TypeComparerTest2()));
            Assert.AreNotEqual(
                TypeComparer.Default.GetHashCode(new TypeComparerTest1()),
                TypeComparer.Default.GetHashCode(null));
        }

        interface ITypeComparerTestInterface { }
        class TypeComparerTest1 : ITypeComparerTestInterface { }
        class TypeComparerTest2 : ITypeComparerTestInterface { }
        class TypeComparerTest3 : ITypeComparerTestInterface { }
    }
}
