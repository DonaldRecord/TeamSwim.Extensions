using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.SystemString.Tests
{
    [TestClass]
    public class ContainsAnyTests : BaseUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Value_Is_Null()
        {
            string value = null;
            var checks = new List<string>();

            var actual = value.ContainsAny(checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Value_Is_Null_Comparison_Ordinal()
        {
            string value = null;
            var checks = new List<string>();

            var actual = value.ContainsAny(StringComparison.OrdinalIgnoreCase, checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Checks_Is_Null()
        {
            var scope = new Scope();

            var value = scope.DefaultValue;
            var checks = scope.NullChecks;

            var actual = value.ContainsAny(checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Checks_Is_Null_Comparison_Ordinal()
        {
            var scope = new Scope();

            var value = scope.DefaultValue;
            var checks = scope.NullChecks;

            var actual = value.ContainsAny(StringComparison.OrdinalIgnoreCase, checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Checks_Is_Null_2()
        {
            var scope = new Scope();

            var value = scope.DefaultValue;
            var checks = scope.NullCheckArray;

            var actual = value.ContainsAny(checks);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAny_Throws_Exception_When_Checks_Is_Null_2_Comparison_Ordinal()
        {
            var scope = new Scope();

            var value = scope.DefaultValue;
            var checks = scope.NullCheckArray;

            var actual = value.ContainsAny(StringComparison.OrdinalIgnoreCase, checks);

            Assert.Fail();
        }

        [TestMethod]
        public void ContainsAny_Returns_True()
        {
            var value = "Value";
            var checks = new List<string> {"u", "x"};

            var actual = value.ContainsAny(checks);
            var expected = true;

            Assert.AreEqual(expected, actual);

            actual = value.ContainsAny(checks.ToArray());
            expected = true;
        }

        [TestMethod]
        public void ContainsAny_Returns_True_Comparison_Overload()
        {
            var value = "Value";
            var checks = new List<string> { "u", "x" };

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