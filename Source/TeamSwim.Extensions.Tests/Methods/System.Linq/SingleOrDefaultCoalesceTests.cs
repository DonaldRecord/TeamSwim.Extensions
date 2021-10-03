﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class SingleOrDefaultCoalesceTests
    {
        [TestMethod]
        public void Second_Delegate_Is_Not_Executed_When_Single_Delegate_Can_Return_a_Result()
        {
            var list = new List<int> { 1, 2, 3 };
            var SingleDelegateExecuted = false;
            var secondDelegateExecuted = false;
            var result = list.SingleOrDefaultCoalesce(
                i =>
                {
                    SingleDelegateExecuted = true;
                    return i == 1;
                },
                i =>
                {
                    secondDelegateExecuted = true;
                    return i == 2;
                });

            Assert.AreEqual(1, result);
            Assert.IsTrue(SingleDelegateExecuted);
            Assert.IsFalse(secondDelegateExecuted);
        }

        [TestMethod]
        public void Second_Delegate_Is_Executed_When_Single_Delegate_Cannot_Return_a_Result()
        {
            var list = new List<int> { 1, 2, 3 };
            var SingleDelegateExecuted = false;
            var secondDelegateExecuted = false;
            var result = list.SingleOrDefaultCoalesce(
                i =>
                {
                    SingleDelegateExecuted = true;
                    return i == 4;
                },
                i =>
                {
                    secondDelegateExecuted = true;
                    return i == 2;
                });

            Assert.AreEqual(2, result);
            Assert.IsTrue(SingleDelegateExecuted);
            Assert.IsTrue(secondDelegateExecuted);
        }

        [TestMethod]
        public void Default_Is_Returned()
        {
            var list = new List<int> { 1, 2, 3 };
            var SingleDelegateExecuted = false;
            var secondDelegateExecuted = false;
            var result = list.SingleOrDefaultCoalesce(
                i =>
                {
                    SingleDelegateExecuted = true;
                    return i == 4;
                },
                i =>
                {
                    secondDelegateExecuted = true;
                    return i == 5;
                });

            Assert.AreEqual(0, result);
            Assert.IsTrue(SingleDelegateExecuted);
            Assert.IsTrue(secondDelegateExecuted);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Throws_Expected_Invalid_Operation_Exception()
        {
            var list = new List<int> { 1, 1, 1 };
            var actual = list.SingleOrDefaultCoalesce(i => i == 2, i => i == 1);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Error_Thrown_For_Null_Predicate_Element()
        {
            var source = new List<int> { 1, 2, 4, 5 };
            var predicates = new List<Func<int, bool>>();
            predicates.Add(i => i % 3 == 0);
            predicates.Add(null);

            var actual = source.SingleOrDefaultCoalesce(predicates.ToArray());

            Assert.Fail();
        }
    }
}