using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class SingleOrDefaultTests
    {
        [TestMethod]
        public void Returns_Expected_Single()
        {
            var a = new[] { 1 }.SingleOrDefault(new NotImplementedException());
            Assert.AreEqual(1, a);

            var b = new[] { 1 }.SingleOrDefault(i => i > 0, new NotImplementedException());
            Assert.AreEqual(1, b);
        }

        [TestMethod]
        public void Returns_Expected_Default()
        {
            var a = Enumerable.Empty<int>().SingleOrDefault(new NotImplementedException());
            Assert.AreEqual(default, a);

            var b = Enumerable.Empty<int>().SingleOrDefault(i => i > 0, new NotImplementedException());
            Assert.AreEqual(default, b);
        }

        [TestMethod]
        public void Throw_Expected_Exceptions()
        {
            IEnumerable<int> nullSequence = null;
            var sequence = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentNullException>(() 
                => nullSequence.SingleOrDefault(new NotImplementedException()));

            Assert.ThrowsException<NotImplementedException>(() 
                => sequence.SingleOrDefault(new NotImplementedException()));

            Assert.ThrowsException<NotImplementedException>(() 
                => sequence.SingleOrDefault(i => i > 0, new NotImplementedException()));
        }
    }
}
