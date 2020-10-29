using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Classes
{
    [TestClass]
    public class SequenceNumberTests
    {
        [TestMethod]
        public void Parameterless_Constructor_Returns_Default_Property_Values()
        {
            var uut = new SequenceNumber();

            Assert.AreEqual(0, uut.Seed);
            Assert.AreEqual(1, uut.Interval);
        }

        [TestMethod]
        public void Is_Not_Incremented_Before_First_Access()
        {
            var uut = new SequenceNumber();
            Assert.AreEqual(0, uut);

            uut = new SequenceNumber(2);
            Assert.AreEqual(2, uut);
        }

        [TestMethod]
        public void Sequential_Access_Returns_Expected_Results()
        {
            var uut = new SequenceNumber(10, 10);
            Assert.AreEqual(10, uut);
            Assert.AreEqual(20, uut);
            Assert.AreEqual(30, uut);
            Assert.AreEqual(40, uut);
            Assert.AreEqual(50, uut);
        }

        [TestMethod]
        public void As_Enumerable_Returns_Expected_Results()
        {
            var uut = new SequenceNumber(10, 10);
            var sequence = uut.AsEnumerable(5).ToList();

            Assert.AreEqual(5, sequence.Count);
            Assert.AreEqual(10, sequence.ElementAt(0));
            Assert.AreEqual(20, sequence.ElementAt(1));
            Assert.AreEqual(30, sequence.ElementAt(2));
            Assert.AreEqual(40, sequence.ElementAt(3));
            Assert.AreEqual(50, sequence.ElementAt(4));
        }

        [TestMethod]
        public void Pause_Without_Increment_Returns_Expected_Values()
        {
            var uut = new SequenceNumber().Pause(false);
            Assert.AreEqual(0, uut);
            Assert.AreEqual(0, uut);
            Assert.AreEqual(0, uut);
        }

        [TestMethod]
        public void Pause_With_Increment_Returns_Expected_Values()
        {
            var uut = new SequenceNumber().Pause(true);
            Assert.AreEqual(1, uut);
            Assert.AreEqual(1, uut);
            Assert.AreEqual(1, uut);
        }

        [TestMethod]
        public void Resume_Changes_Pause_Correctly_Without_Increment()
        {
            var uut = new SequenceNumber().Pause(false);
            Assert.AreEqual(0, uut);
            Assert.AreEqual(0, uut);
            uut.Resume(true);
            Assert.AreEqual(1, uut);
            Assert.AreEqual(2, uut);
            Assert.AreEqual(3, uut);
            uut.Pause(false);
            Assert.AreEqual(3, uut);
            Assert.AreEqual(3, uut);
            Assert.AreEqual(3, uut);
            uut.Resume(false);
            Assert.AreEqual(3, uut);
            Assert.AreEqual(4, uut);
            Assert.AreEqual(5, uut);
            uut.Pause(true);
            Assert.AreEqual(6, uut);
            Assert.AreEqual(6, uut);
            Assert.AreEqual(6, uut);
        }

        [TestMethod]
        public void Resume_Does_Nothing_If_Not_Paused()
        {
            var uut = new SequenceNumber().Pause(false);
            Assert.AreEqual(0, uut);
            uut.Resume(true);
            Assert.AreEqual(1, uut);
            uut.Resume(false);
            Assert.AreEqual(2, uut);
            uut.Resume(true);
            Assert.AreEqual(3, uut);
            uut.Resume(false);
            Assert.AreEqual(4, uut);
        }

        //[TestMethod]
        //public void Thread_Safety_Test()
        //{
        //    const int times = 100;
        //    var results = new Dictionary<int, int>();

        //    for (var i = 0; i < times; i++)
        //    {
        //        var uut = new SequenceNumber();
        //        var last = 0;

        //        Parallel.ForEach(Enumerable.Range(1, 1000), j =>
        //        {
        //            if (j % 2 == 0)
        //                uut.Pause(false);
        //            if (j % 2 == 1)
        //            {
        //                uut.Resume(true);
        //                uut.Current();
        //            }
        //        });

        //        var k = uut.Current();
        //        if (results.ContainsKey(k))
        //            results[k]++;
        //        else
        //            results[k] = 0;
        //    }

        //    var badResults = results.Where(kvp => kvp.Key != 500).ToList();
        //    if (badResults.Any())
        //    {
        //        var resultMsgs = badResults.Select(kvp => $"{kvp.Key} was received {kvp.Value} time(s)");
        //        var msg = $"Bad counts: {String.Join(", ", resultMsgs)}";
        //        Assert.Fail(msg);
        //    }
        //}
    }
}
