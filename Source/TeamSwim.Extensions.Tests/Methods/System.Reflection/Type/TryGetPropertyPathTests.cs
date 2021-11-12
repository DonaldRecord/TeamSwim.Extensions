using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Reflection
{
    [TestClass]
    public class TryGetPropertyPathTests
    {
        [TestMethod]
        public void Single_Path_Returns_Correct_One_Element_Result()
        {

        }

        [TestMethod]
        public void Full_Path_Returns_Expected_Results()
        {

        }

        [TestMethod]
        public void Incorrect_Single_Path_Returns_Expected_False()
        {

        }

        public class TestEntity
        {
            public SubEntity Sub { get; set; }
            public string Name { get; set; }
        }

        public class SubEntity
        {
            public Sub2Entity Sub2 { get; set; }
            public string Name { get; set; }
        }

        public class Sub2Entity
        {
            public string Name { get; set; }
            public DateTime Time { get; set; }
        }
    }
}
