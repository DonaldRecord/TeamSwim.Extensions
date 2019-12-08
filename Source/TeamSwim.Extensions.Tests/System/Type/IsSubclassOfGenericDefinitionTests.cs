using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scope = TeamSwim.Extensions.Tests.System.TypeTests.IsAssignableFromGenericDefinitionTestScope;
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable UnusedVariable

namespace TeamSwim.Extensions.Tests.System.TypeTests
{
    [TestClass]
    public class IsAssignableFromGenericDefinitionTests : BaseUnitTest
    {
        internal const string IsSubclassOfGenericDefinitionTest = "Type.IsSubclassOfGenericDefinition()";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Type_Throws_Exception()
        {
            Type type = null;
            var result = type.IsSubclassOfGenericDefinition(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Generic_Definition_Throws_Exception()
        {
            Type type = null;
            var result = typeof(object).IsSubclassOfGenericDefinition(type);
        }

        [TestMethod]
        public void Same_Non_Generic_Type_Returns_False()
        {
            Type type = typeof(object);
            var result = type.IsSubclassOfGenericDefinition(type);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Unused_Generic_Interface_Returns_False()
        {
            var result = Scope.DefinedImplementedType.IsSubclassOfGenericDefinition(Scope.UnunsedGenericInterfaceType);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Unused_Generic_Class_Returns_False()
        {
            var result = Scope.DefinedImplementedType.IsSubclassOfGenericDefinition(Scope.UnunsedGenericClassType);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Same_Generic_Type_Returns_True()
        {
            Type type = Scope.BaseGenericInterfaceType;
            var result = type.IsSubclassOfGenericDefinition(type);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Non_Generic_Definition_Returns_False()
        {
            var result = Scope.DefinedImplementedType.IsSubclassOfGenericDefinition(Scope.NonGenericType);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Non_Generic_Type_Returns_False()
        {
            var result = Scope.NonGenericType.IsSubclassOfGenericDefinition(Scope.DefinedImplementedType);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Defined_Generic_With_Interface_Definition_Returns_True()
        {
            var result = Scope.DefinedImplementedType.IsSubclassOfGenericDefinition(Scope.BaseGenericInterfaceType);  
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Undefined_Implemented_Interface_With_Interface_Definition_Returns_True()
        {
            var result = Scope.UndefinedImplementedType.IsSubclassOfGenericDefinition(Scope.BaseGenericInterfaceType);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Defined_Implemented_Interface_With_Interface_Definition_Returns_True()
        {
            var result = Scope.DefinedImplementedType.IsSubclassOfGenericDefinition(Scope.BaseGenericInterfaceType);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Undefined_Inherited_Class_With_Class_Definition_Returns_True()
        {
            var result = Scope.UndefinedInheritedType.IsSubclassOfGenericDefinition(typeof(Scope.BaseClassGeneric<>));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Defined_Inherited_Class_With_Class_Definition_Returns_True()
        {
            var result = Scope.DefinedInheritedType.IsSubclassOfGenericDefinition(typeof(Scope.BaseClassGeneric<>));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Undefined_Inherited_Class_Returns_True()
        {
            var result = Scope.SecondLevelUndefinedType.IsSubclassOfGenericDefinition(Scope.MiddleType);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Defined_Inherited_Class_Returns_True()
        {
            var result = Scope.SecondLevelDefinedType.IsSubclassOfGenericDefinition(Scope.MiddleType);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Undefined_Inherited_Class_With_Underlying_Interface_Definition_Returns_True()
        {
            var result = Scope.SecondLevelUndefinedType.IsSubclassOfGenericDefinition(Scope.BaseGenericInterfaceType);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Defined_Inherited_Class_With_Underlying_Interface_Definition_Returns_True()
        {
            var result = Scope.SecondLevelDefinedType.IsSubclassOfGenericDefinition(Scope.BaseGenericInterfaceType);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Correct_Types_Returned_From_First_Generic_Argument_Interface_Type()
        {
            var instance = new Scope.FirstExtraGenericArgumentsInterface<string, int, decimal, float>();
            var type = instance.GetType();

            Type[] outputTypes;
            var result = type.IsSubclassOfGenericDefinition(Scope.BaseGenericInterfaceType, out outputTypes);

            Assert.IsTrue(result);
            Assert.AreEqual(1, outputTypes.Length);
            Assert.AreEqual(typeof(string), outputTypes[0]);
        }

        [TestMethod]
        public void Correct_Types_Returned_From_First_Generic_Argument_Base_Class_Type()
        {
            var instance = new Scope.FirstExtraGenericArgumentsBaseClass<string, int, decimal, float>();
            var type = instance.GetType();

            Type[] outputTypes;
            var result = type.IsSubclassOfGenericDefinition(Scope.BaseGenericClassType, out outputTypes);

            Assert.IsTrue(result);
            Assert.AreEqual(1, outputTypes.Length);
            Assert.AreEqual(typeof(string), outputTypes[0]);
        }

        [TestMethod]
        public void Correct_Types_Returned_From_Random_Generic_Argument_Interface_Type()
        {
            var instance = new Scope.RandomExtraGenericArgumentsInterface<string, int, decimal, float>();
            var type = instance.GetType();

            Type[] outputTypes;
            var result = type.IsSubclassOfGenericDefinition(Scope.BaseGenericInterfaceType, out outputTypes);

            Assert.IsTrue(result);
            Assert.AreEqual(1, outputTypes.Length);
            Assert.AreEqual(typeof(decimal), outputTypes[0]);
        }

        [TestMethod]
        public void Correct_Types_Returned_From_Random_Generic_Argument_Base_Class_Type()
        {
            var instance = new Scope.RandomExtraGenericArgumentsBaseClass<string, int, decimal, float>();
            var type = instance.GetType();

            Type[] outputTypes;
            var result = type.IsSubclassOfGenericDefinition(Scope.BaseGenericClassType, out outputTypes);

            Assert.IsTrue(result);
            Assert.AreEqual(1, outputTypes.Length);
            Assert.AreEqual(typeof(decimal), outputTypes[0]);
        }
    }

    public class IsAssignableFromGenericDefinitionTestScope
    {
        public interface INonGeneric { }
        public interface IBaseInterfaceGeneric1<T> { }
        public interface IDerivedInterfaceGeneric1<T> : IBaseInterfaceGeneric1<T> { }
        public interface IDefinedDerivedInterfaceGeneric1 : IBaseInterfaceGeneric1<object> { }
        public interface IUnusedGenericInterface<T> { }
        public class IUnusedGenericType<T> { }
        public class DefinedInterfaceGeneric1 : IBaseInterfaceGeneric1<object> { }
        public class UndefinedInterfaceGeneric1<T> : IBaseInterfaceGeneric1<T> { }
        public class BaseClassGeneric<T> { }
        public class DefinedClassGeneric : BaseClassGeneric<object> { }
        public class UndefinedClassGeneric<T> : BaseClassGeneric<T> { }
        public class MiddleClassGeneric<T> : IBaseInterfaceGeneric1<T> { }
        public class MiddleDefinedClassGeneric : MiddleClassGeneric<object> { }
        public class MiddleUndefinedClassGeneric<T> : MiddleClassGeneric<T> { }
        public class FirstExtraGenericArgumentsInterface<T1, T2, T3, T4> : IBaseInterfaceGeneric1<T1> { }
        public class FirstExtraGenericArgumentsBaseClass<T1, T2, T3, T4> : BaseClassGeneric<T1> { }
        public class RandomExtraGenericArgumentsInterface<T1, T2, T3, T4> : IBaseInterfaceGeneric1<T3> { }
        public class RandomExtraGenericArgumentsBaseClass<T1, T2, T3, T4> : BaseClassGeneric<T3> { }


        public static Type UnunsedGenericInterfaceType => typeof(IUnusedGenericInterface<>);
        public static Type UnunsedGenericClassType => typeof(IUnusedGenericType<>);
        public static Type NonGenericType => typeof(INonGeneric);
        public static Type BaseGenericInterfaceType => typeof(IBaseInterfaceGeneric1<>);
        public static Type DefinedDerivedGenericInterfaceType => typeof(IDefinedDerivedInterfaceGeneric1);
        public static Type UndefinedDerivedGenericInterfaceType => typeof(IDerivedInterfaceGeneric1<>);
        public static Type DefinedImplementedType => typeof(DefinedInterfaceGeneric1);
        public static Type UndefinedImplementedType => typeof(UndefinedInterfaceGeneric1<>);
        public static Type BaseGenericClassType => typeof(BaseClassGeneric<>);
        public static Type DefinedInheritedType => typeof(DefinedClassGeneric);
        public static Type UndefinedInheritedType => typeof(UndefinedClassGeneric<>);
        public static Type MiddleType => typeof(MiddleClassGeneric<>);
        public static Type SecondLevelUndefinedType => typeof(MiddleUndefinedClassGeneric<>);
        public static Type SecondLevelDefinedType => typeof(MiddleDefinedClassGeneric);
        public static Type FirstExtraGenericArgumentInterfaceType => typeof(FirstExtraGenericArgumentsInterface<,,,>);
        public static Type FirstExtraGenericArgumentBaseClassType => typeof(FirstExtraGenericArgumentsBaseClass<,,,>);
        public static Type RandomExtraGenericArgumentInterfaceType => typeof(RandomExtraGenericArgumentsInterface<,,,>);
        public static Type RandomExtraGenericArgumentBaseClassType => typeof(RandomExtraGenericArgumentsBaseClass<,,,>);

    }
}
