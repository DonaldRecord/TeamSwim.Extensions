﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Linq
{
    [TestClass]
    public class HandleByCountTests
    {
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
    }
}
