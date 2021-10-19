using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Classes
{
    [TestClass]
    public class CollectionProxyTests
    {
        [TestMethod]
        public void Expected_Add_Behavior()
        {
            var uut = TestCollectionProxy.FromElements(1, 2, 3);
            Assert.AreEqual(3, uut.Count);
            uut.Add(4);
            Assert.AreEqual(4, uut.Count);
        }

        [TestMethod]
        public void Expected_Clear_Behavior()
        {
            var uut = TestCollectionProxy.FromElements(1, 2, 3);
            Assert.AreEqual(3, uut.Count);
            uut.Clear();
            Assert.AreEqual(0, uut.Count);
        }

        [TestMethod]
        public void Expected_Remove_Behavior()
        {
            var uut = TestCollectionProxy.FromElements(1, 2, 3);
            Assert.AreEqual(3, uut.Count);
            uut.Remove(2);
            Assert.AreEqual(2, uut.Count);
        }

        [TestMethod]
        public void Echoes_IsReadOnly_Of_Collection()
        {
            var ro = new ReadOnlyCollection<int>(new[] {1, 2});
            var uut = TestCollectionProxy.FromReference(ro);
            Assert.AreEqual(uut.IsReadOnly, ((ICollection<int>)ro).IsReadOnly);
        }
        
        class TestCollectionProxy : CollectionProxy<int>
        {
            private TestCollectionProxy(ICollection<int> source)
            {
                Source = source;
            }

            public static TestCollectionProxy FromReference(ICollection<int> source) => 
                new TestCollectionProxy(source);

            public static TestCollectionProxy FromElements(params int[] elements) =>
                new TestCollectionProxy(elements.ToList());

            protected override ICollection<int> ProxyReference => Source;
            public ICollection<int> Source { get; set; }
        }
    }
}
