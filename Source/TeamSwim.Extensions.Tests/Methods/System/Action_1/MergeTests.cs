using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemAction.MethodTests
{
    [TestClass]
    public class MergeTests : BaseUnitTest
    {
        [TestMethod]
        public void Merge0_Merges_Several_Actions()
        {
            int result = 0;

            Action plusOne = () => result += 1;
            Action plusTwo = () => result += 2;
            Action plusThree = () => result += 3;

            plusOne.Merge(plusTwo, plusThree).Invoke();

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Merge0_Null_Item()
        {
            int result = 0;

            Action plusOne = () => result += 1;
            Action plusTwo = null;
            Action plusThree = () => result += 3;

            plusOne.Merge(plusTwo, plusThree).Invoke();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Merge1_Merges_Several_Actions()
        {
            int result = 0;

            Action<int> plusOne = i => result += 1;
            Action<int> plusTwo = i => result += 2;
            Action<int> plusThree = i => result += 3;

            plusOne.Merge(plusTwo, plusThree).Invoke(result);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Merge1_Null_Item()
        {
            int result = 0;

            Action<int> plusOne = i => result += 1;
            Action<int> plusTwo = null;
            Action<int> plusThree = i => result += 3;

            plusOne.Merge(plusTwo, plusThree).Invoke(result);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Merge2_Merges_Several_Actions()
        {
            int r1 = 0;
            int r2 = 0;

            Func<int, Action<int, int>> createAction = i =>
                (i1, i2) =>
                {
                    r1 += i;
                    r2 += i;
                };

            createAction(1).Merge(createAction(2), createAction(3)).Invoke(r1, r2);

            Assert.AreEqual(6, r1);
            Assert.AreEqual(6, r2);
        }

        [TestMethod]
        public void Merge2_Null_Item()
        {
            int r1 = 0;
            int r2 = 0;

            Func<int, Action<int, int>> createAction = i =>
                (i1, i2) =>
                {
                    r1 += i;
                    r2 += i;
                };

            createAction(1).Merge(null, createAction(3)).Invoke(r1, r2);

            Assert.AreEqual(4, r1);
            Assert.AreEqual(4, r2);
        }

        [TestMethod]
        public void Merge3_Merges_Several_Actions()
        {
            int r1 = 0;
            int r2 = 0;
            int r3 = 0;

            Func<int, Action<int, int, int>> createAction = i =>
                (i1, i2, i3) =>
                {
                    r1 += i;
                    r2 += i;
                    r3 += i;
                };

            createAction(1).Merge(createAction(2), createAction(3)).Invoke(r1, r2, r3);

            Assert.AreEqual(6, r1);
            Assert.AreEqual(6, r2);
            Assert.AreEqual(6, r3);
        }

        [TestMethod]
        public void Merge3_Null_Item()
        {
            int r1 = 0;
            int r2 = 0;
            int r3 = 0;

            Action<int, int, int> CreateAction(int i) =>
                (i1, i2, i3) =>
                {
                    r1 += i;
                    r2 += i;
                    r3 += i;
                };

            CreateAction(1).Merge(null, CreateAction(3)).Invoke(r1, r2, r3);

            Assert.AreEqual(4, r1);
            Assert.AreEqual(4, r2);
            Assert.AreEqual(4, r3);
        }
    }
}
