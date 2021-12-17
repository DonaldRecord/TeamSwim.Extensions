using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Threading
{
    [TestClass]
    public class AsCompletedTaskTests
    {
        [TestMethod]
        public void Returns_Completed_Task()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var result = token.AsCompletedTask();

            Assert.IsInstanceOfType(result, typeof(Task));
        }

        [TestMethod]
        [ExpectedException(typeof(OperationCanceledException))]
        public void Throws_Expected_Error()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            cts.Cancel();

            var result = token.AsCompletedTask();

            Assert.Fail();
        }
    }
}
