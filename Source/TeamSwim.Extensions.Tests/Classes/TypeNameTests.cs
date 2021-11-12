using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamSwim.Extensions.Classes;

namespace System.Classes
{
    [TestClass]
    public class TypeNameTests
    {
        [TestMethod]
        public void Expected_None()
        {
            var uut = TypeName.Parse("int");

            Assert.AreEqual("int", uut.Name);
            Assert.IsFalse(uut.TypeArguments.Any());
            Assert.IsFalse(uut.ArrayDimensions.Any());
            Assert.AreEqual("int", uut.ToString());
            Assert.IsFalse(uut.IsGeneric);
            Assert.IsFalse(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_List()
        {
            var uut = TypeName.Parse("List<int>");

            Assert.AreEqual("List", uut.Name);
            Assert.AreEqual("int", uut.TypeArguments[0].Name);
            Assert.AreEqual("List<int>", uut.ToString());
            Assert.IsTrue(uut.IsGeneric);
            Assert.IsFalse(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_List_With_Nullable()
        {
            var uut = TypeName.Parse("List<int? >");

            Assert.AreEqual("List", uut.Name);
            Assert.AreEqual("int?", uut.TypeArguments[0].Name);
            Assert.AreEqual("List<int?>", uut.ToString());
            Assert.IsTrue(uut.IsGeneric);
            Assert.IsFalse(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
            Assert.IsTrue(uut.TypeArguments[0].ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Nullable_Shorthand()
        {
            var uut = TypeName.Parse("int?");

            Assert.AreEqual("int?", uut.Name);
            Assert.IsFalse(uut.IsGeneric);
            Assert.IsFalse(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsTrue(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Nullable()
        {
            var uut = TypeName.Parse("Nullable<int>");

            Assert.AreEqual("Nullable", uut.Name);
            Assert.AreEqual("int", uut.TypeArguments[0].Name);
            Assert.IsTrue(uut.IsGeneric);
            Assert.IsFalse(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Multidimensional_List_With_Bad_Formatting()
        {
            var uut = TypeName.Parse("List< List<  List <int >   >  >");

            Assert.AreEqual("List", uut.Name);
            Assert.AreEqual("List", uut.TypeArguments[0].Name);
            Assert.AreEqual("List", uut.TypeArguments[0].TypeArguments[0].Name);
            Assert.AreEqual("int", uut.TypeArguments[0].TypeArguments[0].TypeArguments[0].Name);
            Assert.AreEqual("List<List<List<int>>>", uut.ToString());
            Assert.IsTrue(uut.IsGeneric);
            Assert.IsFalse(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Simple_Dictionary()
        {
            var uut = TypeName.Parse("Dictionary<string, object>");

            Assert.AreEqual("Dictionary", uut.Name);
            Assert.AreEqual("string", uut.TypeArguments[0].Name);
            Assert.AreEqual("object", uut.TypeArguments[1].Name);
            Assert.IsTrue(uut.IsGeneric);
            Assert.IsFalse(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Complex_Dictionary()
        {
            var uut = TypeName.Parse("IReadOnlyDictionary<string, Tuple<string, object, IEnumerable<string>>>");

            Assert.AreEqual("IReadOnlyDictionary", uut.Name);
            Assert.AreEqual("string", uut.TypeArguments[0].Name);
            Assert.AreEqual("Tuple", uut.TypeArguments[1].Name);
            Assert.AreEqual("Tuple<string, object, IEnumerable<string>>", uut.TypeArguments[1].ToString());
            Assert.IsTrue(uut.IsGeneric);
            Assert.IsFalse(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Open_Generic_Behavior()
        {
            var uut = TypeName.Parse("IReadOnlyDictionary<,>");

            Assert.AreEqual("IReadOnlyDictionary", uut.Name);
            Assert.AreEqual("", uut.TypeArguments[0].Name);
            Assert.AreEqual("", uut.TypeArguments[1].Name);
            Assert.AreEqual(2, uut.TypeArguments.Count);
            Assert.IsTrue(uut.IsGeneric);
            Assert.IsTrue(uut.IsOpenGeneric);
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Custom_Class_Behavior()
        {
            var uut = TypeName.Parse("MyCustomType");

            Assert.AreEqual("MyCustomType", uut.Name);
            Assert.IsFalse(uut.IsGeneric);
            Assert.IsFalse(uut.TypeArguments.Any());
            Assert.IsFalse(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Simple_Array_Type_Behavior()
        {
            var uut = TypeName.Parse("int[]");

            Assert.AreEqual("int", uut.Name);
            Assert.AreEqual(1, uut.ArrayDimensions.Count);
            Assert.AreEqual(1, uut.ArrayDimensions.Single().Dimensions);
            Assert.AreEqual("[]", uut.ArrayDimensions.Single().ToString());
            Assert.IsTrue(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Simple_Nullable_Array_Type_Behavior()
        {
            var uut = TypeName.Parse("int?[]");

            Assert.AreEqual("int?", uut.Name);
            Assert.AreEqual(1, uut.ArrayDimensions.Count);
            Assert.AreEqual(1, uut.ArrayDimensions.Single().Dimensions);
            Assert.AreEqual("[]", uut.ArrayDimensions.Single().ToString());
            Assert.IsTrue(uut.IsArray);
            Assert.IsTrue(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Multi_Dimensional_Array_Behavior()
        {
            var uut = TypeName.Parse("int[,,]");

            Assert.AreEqual("int", uut.Name);
            Assert.AreEqual(1, uut.ArrayDimensions.Count);
            Assert.AreEqual(3, uut.ArrayDimensions.Single().Dimensions);
            Assert.AreEqual("[,,]", uut.ArrayDimensions.Single().ToString());
            Assert.IsTrue(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Complex_Array_Behavior()
        {
            var uut = TypeName.Parse("int[,,][,][,,,][]");

            Assert.AreEqual("int", uut.Name);
            Assert.AreEqual(4, uut.ArrayDimensions.Count);
            Assert.AreEqual(3, uut.ArrayDimensions.ElementAt(0).Dimensions);
            Assert.AreEqual(2, uut.ArrayDimensions.ElementAt(1).Dimensions);
            Assert.AreEqual(4, uut.ArrayDimensions.ElementAt(2).Dimensions);
            Assert.AreEqual(1, uut.ArrayDimensions.ElementAt(3).Dimensions);
            Assert.AreEqual("[,,]", uut.ArrayDimensions.ElementAt(0).ToString());
            Assert.AreEqual("[,]", uut.ArrayDimensions.ElementAt(1).ToString());
            Assert.AreEqual("[,,,]", uut.ArrayDimensions.ElementAt(2).ToString());
            Assert.AreEqual("[]", uut.ArrayDimensions.ElementAt(3).ToString());
            Assert.IsTrue(uut.IsArray);
            Assert.IsFalse(uut.ContainsNullableShorthand);
        }

        [TestMethod]
        public void Expected_Format_Exceptions()
        {
            Assert.ThrowsException<FormatException>(() => TypeName.Parse("List<int"));
            Assert.IsFalse(TypeName.CanParse("List<int", out _));

            Assert.ThrowsException<FormatException>(() => TypeName.Parse("int["));
            Assert.IsFalse(TypeName.CanParse("int[", out _));

            Assert.ThrowsException<FormatException>(() => TypeName.Parse("int[[]]"));
            Assert.IsFalse(TypeName.CanParse("int[[]]", out _));
        }
    }
}
