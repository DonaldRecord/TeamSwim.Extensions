using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class FirstCoalesceTests
    {
        [TestMethod]
        public void Second_Delegate_Is_Not_Executed_When_First_Delegate_Can_Return_a_Result()
        {
            var list = new List<int> { 1, 2, 3 };
            var firstDelegateExecuted = false;
            var secondDelegateExecuted = false;
            var result = list.FirstCoalesce(
                i =>
                {
                    firstDelegateExecuted = true;
                    return i == 1;
                },
                i =>
                {
                    secondDelegateExecuted = true;
                    return i == 2;
                });

            Assert.AreEqual(1, result);
            Assert.IsTrue(firstDelegateExecuted);
            Assert.IsFalse(secondDelegateExecuted);
        }

        [TestMethod]
        public void Second_Delegate_Is_Executed_When_First_Delegate_Cannot_Return_a_Result()
        {
            var list = new List<int> { 1, 2, 3 };
            var firstDelegateExecuted = false;
            var secondDelegateExecuted = false;
            var result = list.FirstCoalesce(
                i =>
                {
                    firstDelegateExecuted = true;
                    return i == 4;
                },
                i =>
                {
                    secondDelegateExecuted = true;
                    return i == 2;
                });

            Assert.AreEqual(2, result);
            Assert.IsTrue(firstDelegateExecuted);
            Assert.IsTrue(secondDelegateExecuted);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Error_Is_Thrown_For_No_Elements()
        {
            var list = new List<int> { 1, 2, 3 };
            var firstDelegateExecuted = false;
            var secondDelegateExecuted = false;
            var result = list.FirstCoalesce(
                i =>
                {
                    firstDelegateExecuted = true;
                    return i == 4;
                },
                i =>
                {
                    secondDelegateExecuted = true;
                    return i == 5;
                });

            Assert.Fail();
        }

    }
}
