using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Classes
{
    [TestClass]
    public class CurrentDomainCacheTests
    {
        [TestMethod]
        public void Get_Tests()
        {
            Assert.IsNotNull(CurrentDomainCache.Types);
            Assert.IsNotNull(CurrentDomainCache.Assemblies);
        }
    }
}
