#if NET5_0 || NET6_0
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Threading
{
    [TestClass]
    public class AsCompleteValueTaskTests
    {
        [TestMethod]
        public void Returns_Completed_Task()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var result = token.AsCompletedValueTask();

            Assert.IsInstanceOfType(result, typeof(ValueTask));
        }

        [TestMethod]
        [ExpectedException(typeof(OperationCanceledException))]
        public void Throws_Expected_Error()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            cts.Cancel();

            var result = token.AsCompletedValueTask();

            Assert.Fail();
        }

        [TestMethod]
        public async Task Returns_Expected_Value()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var result = await token.AsCompletedValueTask(1);

            Assert.AreEqual(1, result);
        }
    }
}
#endif