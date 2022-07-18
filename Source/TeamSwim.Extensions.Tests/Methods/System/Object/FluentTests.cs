using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class FluentTests
    {
        [TestMethod]
        public void Fluent_Without_Self_Reference_Expected_Behavior()
        {
            var expected = "asdf";
            var scope = new Scope();
            scope.Fluent(() => scope.Name = expected);
            Assert.AreEqual(expected, scope.Name);
        }

        [TestMethod]
        public void Fluent_With_Self_Reference_Expected_Behavior()
        {
            var expected = "asdf";
            var scope = new Scope();
            scope.Fluent(s => s.Name = expected);
            Assert.AreEqual(expected, scope.Name);
        }

        class Scope
        {
            public string Name { get; set; }
        }
    }
}
