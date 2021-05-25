using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Reflection.Tests
{
    [TestClass]
    public class GetDefaultValueTests : BaseUnitTest
    {
        internal const string GetDefaultTest = "String.GetDefaultValue()";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Type_Throws_ArgumentNullException()
        {
            Type t = null;
            t.GetDefaultValue();
        }

        [TestMethod]
        public void String_Returns_Null()
        {
            Assert.IsNull(typeof(string).GetDefaultValue());
        }
        
        [TestMethod]
        public void Activator_Create_Instance_Value_Type_Without_Arguments()
        {
            var type = typeof(TestStruct);
            var actual = (TestStruct)type.GetDefaultValue();
            Assert.IsFalse(actual.ConstructedWithArguments);
        }

        [TestMethod]
        public void Default_Reference_Type_Is_Null_Without_Constructor_Arguments()
        {
            var type = typeof(TestClass);
            Assert.IsNull(type.GetDefaultValue());
        }

        public struct TestStruct
        {
            public bool ConstructedWithArguments { get; }

            public TestStruct(params object[] objs)
            {
                ConstructedWithArguments = true;
            }
        }

        public class TestClass
        {
            public string Prop1 { get; set; }
        }
    }
}
