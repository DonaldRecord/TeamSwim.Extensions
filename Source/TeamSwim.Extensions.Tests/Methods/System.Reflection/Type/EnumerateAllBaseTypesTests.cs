using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Reflection
{
    [TestClass]
    public class EnumerateAllBaseTypesTests
    {
        [TestMethod]
        public void Returns_Expected_Values_For_Built_In_Struct_Type()
        {
            var types = typeof(int).EnumerateAllBaseTypes().ToList();
            Assert.AreEqual(2, types.Count);
            Assert.AreEqual(typeof(ValueType), types[0]);
            Assert.AreEqual(typeof(object), types[1]);
        }

        [TestMethod]
        public void Returns_Expected_Values_For_Built_In_Ref_Type()
        {
            var types = typeof(string).EnumerateAllBaseTypes().ToList();
            Assert.AreEqual(1, types.Count);
            Assert.AreEqual(typeof(object), types[0]);
        }

        [TestMethod]
        public void Returns_Expected_Values_For_Custom_Type()
        {
            var types = typeof(Derived).EnumerateAllBaseTypes().ToList();
            Assert.AreEqual(5, types.Count);
            Assert.AreEqual(typeof(Base4), types[0]);
            Assert.AreEqual(typeof(Base3), types[1]);
            Assert.AreEqual(typeof(Base2), types[2]);
            Assert.AreEqual(typeof(Base1), types[3]);
            Assert.AreEqual(typeof(object), types[4]);
        }

        class Base1 { }
        class Base2 : Base1 { }
        class Base3 : Base2 { }
        class Base4 : Base3 { }
        class Derived : Base4 { }
    }
}
