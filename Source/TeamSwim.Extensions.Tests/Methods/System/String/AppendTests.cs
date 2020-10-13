using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedVariable
// ReSharper disable AssignNullToNotNullAttribute

namespace TeamSwim.Extensions.Tests.SystemTests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class AppendTests : BaseUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Value_Throws_Argument_Null_Exception()
        {
            string value = null;
            string appendText = Utility.RandomString();

            Assert.IsNull(value.Append(appendText, false));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Append_Text_Throws_Argument_Null_Exception()
        {
            string value = Utility.RandomString();
            string appendText = null;

            var result = value.Append(appendText, false);
            Assert.Fail();
        }

        [TestMethod]
        public void String_Is_Not_Appended_When_Bool_Is_True_And_Value_Ends_With()
        {
            string actual = Utility.RandomString();
            string appendText = actual.Last().ToString();

            string expected = actual.Append(appendText, true);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void String_Is_Appended_When_Bool_Is_True_And_Value_Doesnt_End_With()
        {
            string actual = "abcd";
            string appendText = "e";

            string expected = actual.Append(appendText, true);

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void String_Is_Appended_When_Bool_Is_False()
        {
            string actual = "abcd";
            string appendText = "e";

            string expected = actual.Append(appendText, false);

            Assert.AreNotEqual(actual, expected);
        }

        //OVERLOADS

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Value_Throws_Exception_Comparison_Overload()
        {
            string value = null;
            string appendText = Utility.RandomString();

            var result = value.Append(appendText, false, StringComparison.CurrentCulture);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Append_Text_Throws_Argument_Null_Exception_Comparison_Overload()
        {
            string value = Utility.RandomString();
            string appendText = null;

            var result = value.Append(appendText, false, StringComparison.CurrentCulture);
            Assert.Fail();
        }

        [TestMethod]
        public void String_Is_Not_Appended_When_Bool_Is_True_And_Value_Ends_With_Comparison_Overload()
        {
            string actual = Utility.RandomString();
            string appendText = actual.Last().ToString();

            string expected = actual.Append(appendText, true, StringComparison.Ordinal);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void String_Is_Appended_When_Bool_Is_True_And_Value_Doesnt_End_With_Comparison_Overload()
        {
            string actual = "abcd";
            string appendText = "e";

            string expected = actual.Append(appendText, true, StringComparison.Ordinal);

            Assert.AreNotEqual(actual, expected);
        }
        
        [TestMethod]
        public void String_Is_Appended_When_Bool_Is_False_Comparison_Overload()
        {
            string actual = "abcd";
            string appendText = "e";

            string expected = actual.Append(appendText, false, StringComparison.Ordinal);

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void String_Is_Appended_When_No_Bool_Is_Specified()
        {
            string actual = "abcd";
            string appendText = "e";

            string expected = actual.Append(appendText);

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void Char_Is_Appended_When_Bool_Is_False_Comparison_Overload()
        {
            string actual = "abcd"; 
            char appendChar = 'e';

            string expected = actual.Append(appendChar, false, StringComparison.Ordinal);

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void Char_Is_Appended_When_Bool_Is_False()
        {
            string actual = "abcd";
            char appendChar = 'e';

            string expected = actual.Append(appendChar, false);

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void Char_Is_Appended_When_No_Bool_Is_Specified()
        {
            string actual = "abcd";
            char appendChar = 'e';

            string expected = actual.Append(appendChar);

            Assert.AreNotEqual(actual, expected);
        }
    }
}
