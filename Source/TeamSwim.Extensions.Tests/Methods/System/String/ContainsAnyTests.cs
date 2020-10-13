using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.SystemTests
{
    [TestClass]
    public class ContainsAnyTests : BaseUnitTest
    {
        public const string ContainsAny = "String.ContainsAny()";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Value_Is_Null()
        {
            string value = null;
            List<string> checks = new List<string>();

            var actual = value.ContainsAny(checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Value_Is_Null_Comparison_Ordinal()
        {
            string value = null;
            List<string> checks = new List<string>();

            var actual = value.ContainsAny(StringComparison.OrdinalIgnoreCase, checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Checks_Is_Null()
        {
            var scope = new Scope();

            string value = scope.DefaultValue;
            var checks = scope.NullChecks;

            var actual = value.ContainsAny(checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Checks_Is_Null_Comparison_Ordinal()
        {
            var scope = new Scope();

            string value = scope.DefaultValue;
            var checks = scope.NullChecks;

            var actual = value.ContainsAny(StringComparison.OrdinalIgnoreCase, checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Checks_Is_Null_2()
        {
            var scope = new Scope();

            string value = scope.DefaultValue;
            var checks = scope.NullCheckArray;

            var actual = value.ContainsAny(checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Checks_Is_Null_2_Comparison_Ordinal()
        {
            var scope = new Scope();

            string value = scope.DefaultValue;
            var checks = scope.NullCheckArray;

            var actual = value.ContainsAny(StringComparison.OrdinalIgnoreCase, checks);

            Assert.Fail();
        }

        [TestMethod]
        public void ContainsAny_Returns_True()
        {
            string value = "Value";
            List<string> checks = new List<string> {"u", "x"};

            var actual = value.ContainsAny(checks);
            var expected = true;

            Assert.AreEqual(expected, actual);

            actual = value.ContainsAny(checks.ToArray());
            expected = true;
        }

        [TestMethod]
        public void ContainsAny_Returns_True_Comparison_Overload()
        {
            string value = "Value";
            List<string> checks = new List<string> { "u", "x" };

            var actual = value.ContainsAny(StringComparison.OrdinalIgnoreCase, checks);
            var expected = true;

            Assert.AreEqual(expected, actual);

            actual = value.ContainsAny(StringComparison.OrdinalIgnoreCase ,checks.ToArray());
            expected = true;

            Assert.AreEqual(expected, actual);

        }
        private class Scope
        {
            public string DefaultValue => "String";
            public IEnumerable<string> NullChecks => null;

            public string[] NullCheckArray => null;
        }
    }
}