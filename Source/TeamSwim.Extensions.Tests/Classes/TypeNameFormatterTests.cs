using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Classes
{
    [TestClass]
    public class TypeNameFormatterTests
    {
        [TestMethod]
        public void Expected_Default_Values()
        {
            AssertValue(typeof(string), "string", TypeNameFormattingOptions.Default);
            AssertValue(typeof(List<string>), "List<string>", TypeNameFormattingOptions.Default);
            AssertValue(typeof(Dictionary<string, object>), "Dictionary<string, object>", TypeNameFormattingOptions.Default);
            AssertValue(typeof(Dictionary<,>), "Dictionary<TKey, TValue>", TypeNameFormattingOptions.Default);
            AssertValue(typeof(List<>), "List<T>", TypeNameFormattingOptions.Default);
            AssertValue(typeof(IDynamicMetaObjectProvider), "dynamic", TypeNameFormattingOptions.Default);
            AssertValue(typeof(StringComparison), "StringComparison", TypeNameFormattingOptions.Default);
            AssertValue(typeof(int[]), "int[]", TypeNameFormattingOptions.Default);
            AssertValue(typeof(DynamicObject), "dynamic", TypeNameFormattingOptions.Default);
        }

        [TestMethod]
        public void Expected_Enum_Values()
        {
            AssertValue(typeof(StringComparison), "Enum", TypeNameFormattingOptions.UseEnumKeyword);
            AssertValue(typeof(StringComparison?), "Nullable<Enum>", TypeNameFormattingOptions.UseEnumKeyword);
            AssertValue(typeof(StringComparison?), "Enum?", TypeNameFormattingOptions.UseEnumKeyword | TypeNameFormattingOptions.UseQuestionMarkForNullable);
        }

        [TestMethod]
        public void Expected_Fully_Qualified_Values()
        {
            AssertValue(typeof(string), typeof(string).FullName, TypeNameFormattingOptions.FullyQualified);
            AssertValue(typeof(List<string>), "System.Collections.Generic.List<System.String>", TypeNameFormattingOptions.FullyQualified);
            AssertValue(typeof(Dictionary<string, object>), "System.Collections.Generic.Dictionary<System.String, System.Object>", TypeNameFormattingOptions.FullyQualified);
            AssertValue(typeof(Dictionary<,>), "System.Collections.Generic.Dictionary<,>", TypeNameFormattingOptions.FullyQualified);
            AssertValue(typeof(List<>), "System.Collections.Generic.List<>", TypeNameFormattingOptions.FullyQualified);
            AssertValue(typeof(IDynamicMetaObjectProvider), "System.Dynamic.IDynamicMetaObjectProvider", TypeNameFormattingOptions.FullyQualified);
            AssertValue(typeof(StringComparison), "System.StringComparison", TypeNameFormattingOptions.FullyQualified);
            AssertValue(typeof(int[]), "System.Int32[]", TypeNameFormattingOptions.FullyQualified);
            AssertValue(typeof(DynamicObject), "System.Dynamic.DynamicObject", TypeNameFormattingOptions.FullyQualified);
        }


        private void AssertValue(Type type, string expected, TypeNameFormattingOptions options)
        {
            var actual = TypeNameFormatter.GetName(type, options);
            Assert.AreEqual(expected, actual);
        }
    }
}
