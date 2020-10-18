//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace System.Classes
//{
//    [TestClass]
//    public class InstanceComparerTests
//    {
//        [TestMethod]
//        public void Returns_Expected_True()
//        {
            
//        }

//        [TestMethod]
//        public void Returns_Expected_False()
//        {

//        }

//        [TestMethod]
//        public void Invalid_Property_Expression_Throws_Exception()
//        {

//        }

//        [TestMethod]
//        public void Invalid_Field_Expression_Throws_Exception()
//        {

//        }

//        [TestMethod]
//        public void Invalid_Member_Expression_Throws_Exception()
//        {

//        }

//        public class InstanceComparerTestScope
//        {
//            public TestClass Instance1 { get; }
//            public TestClass Instance2 { get; }
//            public TestSubClass SubInstance1 { get; }
//            public TestSubClass SubInstance2 { get; }

//            public InstanceComparerTestScope()
//            {
//                SubInstance1 = new TestSubClass
//                {
//                    NumberProperty = Utility.RandomInteger(),
//                    StringProperty = Utility.RandomString()
//                };

//                SubInstance2 = new TestSubClass
//                {
//                    NumberProperty = Utility.RandomInteger(),
//                    StringProperty = Utility.RandomString(5, 8)
//                };

//                Instance1 = new TestClass
//                {
//                    NumberProperty = Utility.RandomInteger(),
//                    StringProperty = Utility.RandomString(),
//                    ComplexProperty = SubInstance1
//                };

//                Instance2 = new TestClass
//                {
//                    NumberProperty = Utility.RandomInteger(),
//                    StringProperty = Utility.RandomString(5, 8),
//                    ComplexProperty = SubInstance2
//                };
//            }

//            public static void AssertEquals(
//                Action<InstanceComparerTestScope> scope,
//                Func<InstanceComparer<TestClass>, InstanceComparer<TestClass>> comparer,
//                bool expectedResult)
//            {
//                var scopeInstance = new InstanceComparerTestScope();
//                scope.Invoke(scopeInstance);
//                var comparerInstance = comparer.Invoke(new InstanceComparer<TestClass>());
//                var actual = comparerInstance.Equals(scopeInstance.Instance1, scopeInstance.Instance2);
//                Assert.AreEqual(expectedResult, actual);
//            }
//        }

//        public class TestClass
//        {
//            public string StringProperty { get; set; }
//            public int NumberProperty { get; set; }
//            public TestSubClass ComplexProperty { get; set; }
//        }

//        public class TestSubClass
//        {
//            public string StringProperty { get; set; }
//            public int NumberProperty { get; set; }
//        }
//    }
//}
