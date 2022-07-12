using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RemoveFromBeginningTests
{
    [TestMethod]
    public void Throws_Expected_Exceptions()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((string)null).RemoveFromEnding(""));
        Assert.ThrowsException<ArgumentNullException>(() => "".RemoveFromEnding(null));
    }

    [TestMethod]
    public void Assert_String_Empty_Value_ReferenceEquals()
    {
        var value = "";
        var result = value.RemoveFromEnding("asdf");
        Assert.IsTrue(ReferenceEquals(value, result));
    }

    [TestMethod]
    public void Assert_String_Empty_Substring_ReferenceEquals()
    {
        var value = "asdf";
        var result = value.RemoveFromEnding("");
        Assert.IsTrue(ReferenceEquals(value, result));
    }

    [TestMethod]
    public void Assert_Expected_Results()
    {
        void AssertValue(string value, string substring, StringComparison stringComparison, string expected)
        {
            var actual = value.RemoveFromEnding(substring, stringComparison);
            Assert.AreEqual(expected, actual);
        }

        AssertValue("AAABBB", "BBB", StringComparison.Ordinal, "AAA");
        AssertValue("AAABBB", "bbb", StringComparison.OrdinalIgnoreCase, "AAA");
        AssertValue("ccc", "aaa", StringComparison.Ordinal, "ccc");
        AssertValue("a", "a", StringComparison.Ordinal, "");
        AssertValue("ba", "a", StringComparison.Ordinal, "b");
    }
}