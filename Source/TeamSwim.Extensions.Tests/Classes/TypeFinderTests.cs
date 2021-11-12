using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Classes
{
    [TestClass]
    public class TypeFinderTests
    {
        [TestMethod]
        public void Test_Basic()
        {
            var actual = TypeFinder.FindType("Sample");
            Assert.AreEqual(typeof(Sample), actual);
        }

        [TestMethod]
        public void Test_Open_Generic()
        {
            var actual = TypeFinder.FindType("Sample<>");
            Assert.AreEqual(typeof(Sample<>), actual);
        }

        [TestMethod]
        public void Test_Multiple_Open_Generic()
        {
            var actual = TypeFinder.FindType("Tuple<,,,,>");
            Assert.AreEqual(typeof(Tuple<,,,,>), actual);
        }

        [TestMethod]
        public void Test_Basic_Struct()
        {
            var actual = TypeFinder.FindType("int");
            Assert.AreEqual(typeof(Int32), actual);
        }

        [TestMethod]
        public void Test_Basic_Nullable_Struct()
        {
            var actual = TypeFinder.FindType("int?");
            Assert.AreEqual(typeof(int?), actual);
        }

        [TestMethod]
        public void Test_Basic_Incorrect_Case()
        {
            var actual = TypeFinder.FindType("SAMPLE");
            Assert.AreEqual(typeof(Sample), actual);
        }

        [TestMethod]
        public void Test_Keyword()
        {
            var actual = TypeFinder.FindType("string");
            Assert.AreEqual(typeof(string), actual);
        }

        [TestMethod]
        public void Test_FullName()
        {
            var actual = TypeFinder.FindType("System.String");
            Assert.AreEqual(typeof(string), actual);
        }

        [TestMethod]
        public void Test_FullName_Incorrect_Case()
        {
            var actual = TypeFinder.FindType("system.string");
            Assert.AreEqual(typeof(string), actual);
        }

        [TestMethod]
        public void Test_Invalid_Nullable_Shorthand_Is_Ignored()
        {
            var actual = TypeFinder.FindType("string?");
            Assert.AreEqual(typeof(string), actual);
        }


        [TestMethod]
        public void Test_Single_Array()
        {
            var actual = TypeFinder.FindType("string[]");
            Assert.AreEqual(typeof(string[]), actual);
        }

        [TestMethod]
        public void Test_Nested_Single_Array()
        {
            var actual = TypeFinder.FindType("string[][][]");
            Assert.AreEqual(typeof(string[][][]), actual);
        }

        [TestMethod]
        public void Test_Multidimensional_Arrays()
        {
            var actual = TypeFinder.FindType("string[,,,][,][]");
            Assert.AreEqual(typeof(string[,,,][,][]), actual);
        }

        [TestMethod]
        public void Test_Simple_Generic()
        {
            var actual = TypeFinder.FindType("List<string>");
            Assert.AreEqual(typeof(List<string>), actual);
        }

        [TestMethod]
        public void Test_Simple_Dictionary()
        {
            var actual = TypeFinder.FindType("Dictionary<string, object>");
            Assert.AreEqual(typeof(Dictionary<string, object>), actual);
        }

        [TestMethod]
        public void Test_Simple_Dictionary_With_Nullable()
        {
            var actual = TypeFinder.FindType("Dictionary<Guid?, int?>");
            Assert.AreEqual(typeof(Dictionary<Guid?, int?>), actual);
        }

        [TestMethod]
        public void Test_Simple_Tuple()
        {
            var actual = TypeFinder.FindType("Tuple<string, int, long, Guid, DateTime, DateTimeOffset>");
            Assert.AreEqual(typeof(Tuple<string, int, long, Guid, DateTime, DateTimeOffset>), actual);
        }

        [TestMethod]
        public void Test_Func()
        {
            var actual = TypeFinder.FindType("Func<string, object>");
            Assert.AreEqual(typeof(Func<string, object>), actual);
        }

        [TestMethod]
        public void Test_Nested_Generic()
        {
            var actual = TypeFinder.FindType("Tuple<List<string>, HashSet<int>, IDictionary<long, Guid>, IReadOnlyCollection<DateTime>, DateTimeOffset?>");
            Assert.AreEqual(typeof(Tuple<List<string>, HashSet<int>, IDictionary<long, Guid>, IReadOnlyCollection<DateTime>, DateTimeOffset?>), actual);
        }
    }

    public class Sample { }
    public class Sample<T> { }
}
