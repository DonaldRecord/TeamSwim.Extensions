using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Classes
{
    [TestClass]
    public class InstanceComparerProxyTests
    {
        [TestMethod]
        public void Proxy_Calls_Instance_Comparer_Methods()
        {
            var scope = new Scope.ManualProxy();
            var equals = scope.Equals("a", "a");
            Assert.IsTrue(scope.EqualsCalled);
            var hashcode = scope.GetHashCode("a");
            Assert.IsTrue(scope.GetHashCodeCalled);
        }

        class Scope
        {
            public class ManualProxy : InstanceComparerProxy<string>
            {
                private readonly ManualProxyComparer _comparer = new ManualProxyComparer();
                public bool EqualsCalled => _comparer.EqualsCalled;
                public bool GetHashCodeCalled => _comparer.GetHashCodeCalled;
                protected override InstanceComparer<string> ComparerProxy => _comparer;
            }

            public class ManualProxyComparer : InstanceComparer<string>
            {
                public bool EqualsCalled { get; private set; }
                public bool GetHashCodeCalled { get; private set; }

                public override bool Equals(string x, string y)
                {
                    EqualsCalled = true;
                    return base.Equals(x, y);
                }

                public override int GetHashCode([CanBeNull] string obj)
                {
                    GetHashCodeCalled = true;
                    return base.GetHashCode(obj);
                }
            }
        }
    }
}
