//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TeamSwim.Extensions.Tests.System.ObjectTests
//{
//    [TestClass]
//    public sealed class IsDefaultValueTests : BaseUnitTest
//    {
//        internal const string IsDefaultValueTest = "Object.IsDefaultValue()";

//        [TestMethod]
//        [TestCategory(TargetProject), TestCategory(IsDefaultValueTest), TestCategory(TestTraits.ExtensionMethod)]
//        public void Struct_Returns_True_For_Default_Value()
//        {
//            object i = 0;
//            Assert.AreEqual(typeof(int), i.GetType());
//            Assert.IsTrue(i.IsDefaultValue());
//        }

//        [TestMethod]
//        [TestCategory(TargetProject), TestCategory(IsDefaultValueTest), TestCategory(TestTraits.ExtensionMethod)]
//        public void Class_Returns_True_For_Null_Value()
//        {
//            string s = null;
//            Assert.IsTrue(s.IsDefaultValue());
//        }

//        [TestMethod]
//        [TestCategory(TargetProject), TestCategory(IsDefaultValueTest), TestCategory(TestTraits.ExtensionMethod)]
//        public void Struct_Returns_False_For_Non_Default_Value()
//        {
//            object i = 1;
//            Assert.AreEqual(typeof(int), i.GetType());
//            Assert.IsFalse(i.IsDefaultValue());
//        }

//        [TestMethod]
//        [TestCategory(TargetProject), TestCategory(IsDefaultValueTest), TestCategory(TestTraits.ExtensionMethod)]
//        public void Class_Returns_False_For_Non_Null_Value()
//        {
//            string s = Pseudo.Pseudo.String().Exclude(null).Get();
//            Assert.IsFalse(s.IsDefaultValue());
//        }
//    }
//}
