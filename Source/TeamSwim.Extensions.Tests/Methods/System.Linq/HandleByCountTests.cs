using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class HandleByCountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            List<int> source = null;
            source.HandleByCount(() => { }, i => { }, c => { });
            Assert.Fail();
        }

        [TestMethod]
        public void Single_Handler_Expected_Call()
        {
            var source = new List<int> {1};
            var noneHandlerCalled = false;
            Action noneHandler = () => noneHandlerCalled = true;
            var singleHandlerCalled = false;
            Action<int> singleHandler = i => singleHandlerCalled = true;
            var multipleHandlerCalled = false;
            Action<ICollection<int>> multipleHandler = col => multipleHandlerCalled = true;

            source.HandleByCount(noneHandler, singleHandler, multipleHandler);

            Assert.IsFalse(noneHandlerCalled);
            Assert.IsTrue(singleHandlerCalled);
            Assert.IsFalse(multipleHandlerCalled);
        }

        [TestMethod]
        public void None_Handler_Expected_Call()
        {
            var source = new List<int>();
            var noneHandlerCalled = false;
            Action noneHandler = () => noneHandlerCalled = true;
            var singleHandlerCalled = false;
            Action<int> singleHandler = i => singleHandlerCalled = true;
            var multipleHandlerCalled = false;
            Action<ICollection<int>> multipleHandler = col => multipleHandlerCalled = true;

            source.HandleByCount(noneHandler, singleHandler, multipleHandler);

            Assert.IsTrue(noneHandlerCalled);
            Assert.IsFalse(singleHandlerCalled);
            Assert.IsFalse(multipleHandlerCalled);
        }

        [TestMethod]
        public void Many_Handler_Expected_Call()
        {
            var source = new List<int> {1, 2, 3};
            var noneHandlerCalled = false;
            Action noneHandler = () => noneHandlerCalled = true;
            var singleHandlerCalled = false;
            Action<int> singleHandler = i => singleHandlerCalled = true;
            var multipleHandlerCalled = false;
            Action<ICollection<int>> multipleHandler = col => multipleHandlerCalled = true;

            source.HandleByCount(noneHandler, singleHandler, multipleHandler);

            Assert.IsFalse(noneHandlerCalled);
            Assert.IsFalse(singleHandlerCalled);
            Assert.IsTrue(multipleHandlerCalled);
        }

        [TestMethod]
        public void Null_Handlers_No_Errors()
        {
            var source = new List<int> { 1, 2, 3 };
            var noneHandlerCalled = false;
            Action noneHandler = null;
            var singleHandlerCalled = false;
            Action<int> singleHandler = null;
            var multipleHandlerCalled = false;
            Action<ICollection<int>> multipleHandler = null;

            source.HandleByCount(noneHandler, singleHandler, multipleHandler);
        }
    }
}
