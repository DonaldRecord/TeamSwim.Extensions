using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamSwim.Extensions.Tests.SystemTests
{
    [TestClass]
    public class PrependTests : BaseUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Value_Throws_Exception()
        {
            string value = null;
            string appendText = Utility.RandomString();

            Assert.IsNull(value.Prepend(appendText, false));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Prepend_Text_Throws_Argument_Null_Exception()
        {
            string value = Utility.RandomString();
            string appendText = null;

            value.Prepend(appendText, false);
        }

        [TestMethod]
        public void String_Is_Not_Prepended_When_Bool_Is_True_And_Value_Ends_With()
        {
            string actual = Utility.RandomString();
            string appendText = actual.First().ToString();

            string expected = actual.Prepend(appendText, true);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void String_Is_Prepended_When_Bool_Is_True_And_Value_Doesnt_End_With()
        {
            string actual = Utility.RandomString();
            string appendText = Utility.RandomString(exclusion: actual);

            string expected = actual.Prepend(appendText, true);

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void String_Is_Prepended_When_Bool_Is_False()
        {
            string actual = Utility.RandomString();
            string appendText = Utility.RandomString(exclusion: actual);

            string expected = actual.Prepend(appendText, false);

            Assert.AreNotEqual(actual, expected);
        }

        //OVERLOADS

        //[TestMethod]
        //[TestCategory(ProjectName), TestCategory(PrependTest), TestCategory(TestTraits.ExtensionMethod)]
        //public void Null_Value_Returns_Null_Comparison_Overload()
        //{
        //    string value = null;
        //    string appendText = Pseudo.Pseudo.String().NoLongerThan(4).ExcludeDefault();

        //    Assert.IsNull(value.Prepend(appendText, false, StringComparison.CurrentCulture));
        //}

        //[TestMethod]
        //[TestCategory(ProjectName), TestCategory(PrependTest), TestCategory(TestTraits.ExtensionMethod)]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void Null_Prepend_Text_Throws_Argument_Null_Exception_Comparison_Overload()
        //{
        //    string value = Pseudo.Pseudo.String().NoLongerThan(4).ExcludeDefault();
        //    string appendText = null;

        //    value.Prepend(appendText, false, StringComparison.CurrentCulture);
        //}

        //[TestMethod]
        //[TestCategory(ProjectName), TestCategory(PrependTest), TestCategory(TestTraits.ExtensionMethod)]
        //public void String_Is_Not_Prepended_When_Bool_Is_True_And_Value_Ends_With_Comparison_Overload()
        //{
        //    string actual = Pseudo.Pseudo.String().NoLongerThan(4).ExcludeDefault();
        //    string appendText = actual.First().ToString();

        //    string expected = actual.Prepend(appendText, true, StringComparison.Ordinal);

        //    Assert.AreEqual(actual, expected);
        //}

        //[TestMethod]
        //[TestCategory(ProjectName), TestCategory(PrependTest), TestCategory(TestTraits.ExtensionMethod)]
        //public void String_Is_Prepended_When_Bool_Is_True_And_Value_Doesnt_End_With_Comparison_Overload()
        //{
        //    string actual = Pseudo.Pseudo.String().NoLongerThan(4).ExcludeDefault();
        //    string appendText = Pseudo.Pseudo.String().OfLength(1).ExcludeDefault().Exclude(actual.First().ToString());

        //    string expected = actual.Prepend(appendText, true, StringComparison.Ordinal);

        //    Assert.AreNotEqual(actual, expected);
        //}

        //[TestMethod]
        //[TestCategory(ProjectName), TestCategory(PrependTest), TestCategory(TestTraits.ExtensionMethod)]
        //public void String_Is_Prepended_When_Bool_Is_False_Comparison_Overload()
        //{
        //    string actual = Pseudo.Pseudo.String().NoLongerThan(4).ExcludeDefault();
        //    string appendText = Pseudo.Pseudo.String().OfLength(1).ExcludeDefault().Exclude(actual.First().ToString());

        //    string expected = actual.Prepend(appendText, false, StringComparison.Ordinal);

        //    Assert.AreNotEqual(actual, expected);
        //}

        [TestMethod]
        public void String_Is_Prepended_When_No_Bool_Is_Specified()
        {
            string actual = Utility.RandomString();
            string appendText = Utility.RandomString(exclusion: actual);

            string expected = actual.Prepend(appendText);

            Assert.AreNotEqual(actual, expected);
        }

        //[TestMethod]
        //[TestCategory(ProjectName), TestCategory(PrependTest), TestCategory(TestTraits.ExtensionMethod)]
        //public void Char_Is_Prepended_When_Bool_Is_False_Comparison_Overload()
        //{
        //    string actual = Pseudo.Pseudo.String().NoLongerThan(4).ExcludeDefault();
        //    var appendChar = Pseudo.Pseudo.String().OfLength(1).ExcludeDefault().Exclude(actual.First().ToString()).Get().First();

        //    string expected = actual.Prepend(appendChar, false, StringComparison.Ordinal);

        //    Assert.AreNotEqual(actual, expected);
        //}

        [TestMethod]
        public void Char_Is_Prepended_When_Bool_Is_False()
        {
            string actual = Utility.RandomString();
            var appendChar = Utility.RandomString(exclusion: actual.Substring(0, 1)).First();

            string expected = actual.Prepend(appendChar, false);

            Assert.AreNotEqual(actual, expected);
        }

        //[TestMethod]
        //[TestCategory(ProjectName), TestCategory(PrependTest), TestCategory(TestTraits.ExtensionMethod)]
        //public void Char_Is_Prepended_When_No_Bool_Is_Specified()
        //{
        //    string actual = Pseudo.Pseudo.String().NoLongerThan(4).ExcludeDefault();
        //    var appendChar = Pseudo.Pseudo.String().OfLength(1).ExcludeDefault().Exclude(actual.First().ToString()).Get().First();

        //    string expected = actual.Prepend(appendChar);

        //    Assert.AreNotEqual(actual, expected);
        //}
    }
}
