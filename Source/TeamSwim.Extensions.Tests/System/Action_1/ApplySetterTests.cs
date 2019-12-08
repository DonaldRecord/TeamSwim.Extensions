using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestType = TeamSwim.Extensions.Tests.System.Action_1.ApplySetterTestScope.TestType;
// ReSharper disable AssignNullToNotNullAttribute

namespace TeamSwim.Extensions.Tests.System.Action_1
{
    [TestClass]
    public class ApplySetterTests : BaseUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Setter_Throws_Exception()
        {
            Action<TestType> setter = null;
            setter.ApplySetter();
            Assert.Fail();
        }

        [TestMethod]
        public void Setter_Executes()
        {
            var prop1 = RandomString();
            Action<TestType> setter = t => t.Property1 = prop1;
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
