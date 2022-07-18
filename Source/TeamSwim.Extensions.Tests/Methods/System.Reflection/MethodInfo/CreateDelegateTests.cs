//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace System.Reflection
//{
//    [TestClass]
//    public class CreateDelegateTests
//    {
//        [TestMethod]
//        public void Returns_Expected_Values()
//        {
//            void AssertValue(MethodInfo method, Action assert) => assert.Invoke(method.CreateDelegate())
//        }

//        class Scope
//        {
//            public void ActionWithoutParameters() { }

//            public static MethodInfo ActionWithoutParametersMethod =>
//                typeof(Scope).GetMethod(nameof(ActionWithoutParameters));


//        }
//    }
//}
