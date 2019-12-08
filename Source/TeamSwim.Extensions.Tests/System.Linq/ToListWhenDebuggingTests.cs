using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.System.Linq
{
    [TestClass]
    public class ToListWhenDebuggingTests
    {
        [TestMethod]
        public void Result_Does_Not_Inherit_ICollection_Without_Debugger()
        {
            var scope = new Scope();
            var results = scope.ExecuteTest();

            var isCollection = results is ICollection<string>;

            Assert.IsFalse(isCollection);
        }

        public class Scope
        {
            public IEnumerable<string> GetSource()
            {
                yield return Utility.RandomString();
                yield return Utility.RandomString();
                yield return Utility.RandomString();
            }

            public IEnumerable<string> ExecuteTest() => GetSource().ToListWhenDebugging();
        }
    }
}
