using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable AssignNullToNotNullAttribute

namespace TeamSwim.Extensions.SystemAction.Tests
{
    [TestClass]
    public class ApplySetterTests : BaseUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Setter_Throws_Exception()
        {
            Action<ApplySetterTestScope.TestType> setter = null;
            setter.ApplySetter();
            Assert.Fail();
        }

        [TestMethod]
        public void Setter_Executes()
        {
            var prop1 = Utility.RandomString();
            Action<ApplySetterTestScope.TestType> setter = t => t.Property1 = prop1;
            var tt = setter.ApplySetter();
            Assert.IsNotNull(tt);
            Assert.AreEqual(prop1, tt.Property1);
        }
    }

    public class ApplySetterTestScope
    {
        public class TestType
        {
            public string Property1 { get; set; }
        }
    }
}
