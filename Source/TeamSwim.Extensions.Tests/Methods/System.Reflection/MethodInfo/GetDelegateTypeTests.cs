using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Methods.System.Reflection.Tests
{
    [TestClass]
    public class GetDelegateTypeTests
    {
        [TestMethod]
        public void Action0_Returns_Expected_DelegateType()
        {
            var actual = Action0Info.GetDelegateType();
            Assert.AreEqual(typeof(Action), actual);
        }

        [TestMethod]
        public void Action1_Returns_Expected_DelegateType()
        {
            var actual = Action1Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string>), actual);
        }

        [TestMethod]
        public void Action2_Returns_Expected_DelegateType()
        {
            var actual = Action2Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string>), actual);
        }

        [TestMethod]
        public void Action3_Returns_Expected_DelegateType()
        {
            var actual = Action3Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string>), actual);
        }

        [TestMethod]
        public void Action4_Returns_Expected_DelegateType()
        {
            var actual = Action4Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action5_Returns_Expected_DelegateType()
        {
            var actual = Action5Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action6_Returns_Expected_DelegateType()
        {
            var actual = Action6Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action7_Returns_Expected_DelegateType()
        {
            var actual = Action7Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action8_Returns_Expected_DelegateType()
        {
            var actual = Action8Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action9_Returns_Expected_DelegateType()
        {
            var actual = Action9Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action10_Returns_Expected_DelegateType()
        {
            var actual = Action10Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action11_Returns_Expected_DelegateType()
        {
            var actual = Action11Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action12_Returns_Expected_DelegateType()
        {
            var actual = Action12Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action13_Returns_Expected_DelegateType()
        {
            var actual = Action13Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action14_Returns_Expected_DelegateType()
        {
            var actual = Action14Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action15_Returns_Expected_DelegateType()
        {
            var actual = Action15Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Action16_Returns_Expected_DelegateType()
        {
            var actual = Action16Info.GetDelegateType();
            Assert.AreEqual(typeof(Action<string, string, string, string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Action17_Throws_Expected_Exception()
        {
            var actual = Action17Info.GetDelegateType();
            Assert.Fail();
        }

        [TestMethod]
        public void Func1_Returns_Expected_DelegateType()
        {
            var actual = Func1Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string>), actual);
        }

        [TestMethod]
        public void Func2_Returns_Expected_DelegateType()
        {
            var actual = Func2Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string>), actual);
        }

        [TestMethod]
        public void Func3_Returns_Expected_DelegateType()
        {
            var actual = Func3Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string>), actual);
        }

        [TestMethod]
        public void Func4_Returns_Expected_DelegateType()
        {
            var actual = Func4Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func5_Returns_Expected_DelegateType()
        {
            var actual = Func5Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func6_Returns_Expected_DelegateType()
        {
            var actual = Func6Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func7_Returns_Expected_DelegateType()
        {
            var actual = Func7Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func8_Returns_Expected_DelegateType()
        {
            var actual = Func8Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func9_Returns_Expected_DelegateType()
        {
            var actual = Func9Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string>), actual);
        }
        
        [TestMethod]
        public void Func10_Returns_Expected_DelegateType()
        {
            var actual = Func10Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func11_Returns_Expected_DelegateType()
        {
            var actual = Func11Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func12_Returns_Expected_DelegateType()
        {
            var actual = Func12Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func13_Returns_Expected_DelegateType()
        {
            var actual = Func13Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func14_Returns_Expected_DelegateType()
        {
            var actual = Func14Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func15_Returns_Expected_DelegateType()
        {
            var actual = Func15Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func16_Returns_Expected_DelegateType()
        {
            var actual = Func16Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        public void Func17_Returns_Expected_DelegateType()
        {
            var actual = Func17Info.GetDelegateType();
            Assert.AreEqual(typeof(Func<string, string, string, string, string, string, string, string, string, string, string, string, string, string, string, string, string>), actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Func18_Throws_Expected_Exception()
        {
            var actual = Func18Info.GetDelegateType();
            Assert.Fail();
        }

        private void Action0() { }
        private static MethodInfo Action0Info => GetMethodInfo(nameof(Action0));
        
        private void Action1(string s1) { }
        private static MethodInfo Action1Info => GetMethodInfo(nameof(Action1));

        private void Action2(string s1, string s2) { }
        private static MethodInfo Action2Info => GetMethodInfo(nameof(Action2));

        private void Action3(string s1, string s2, string s3) { }
        private static MethodInfo Action3Info => GetMethodInfo(nameof(Action3));

        private void Action4(string s1, string s2, string s3, string s4) { }
        private static MethodInfo Action4Info => GetMethodInfo(nameof(Action4));

        private void Action5(string s1, string s2, string s3, string s4, string s5) { }
        private static MethodInfo Action5Info => GetMethodInfo(nameof(Action5));

        private void Action6(string s1, string s2, string s3, string s4, string s5, string s6) { }
        private static MethodInfo Action6Info => GetMethodInfo(nameof(Action6));

        private void Action7(string s1, string s2, string s3, string s4, string s5, string s6, string s7) { }
        private static MethodInfo Action7Info => GetMethodInfo(nameof(Action7));

        private void Action8(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8) { }
        private static MethodInfo Action8Info => GetMethodInfo(nameof(Action8));

        private void Action9(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9) { }
        private static MethodInfo Action9Info => GetMethodInfo(nameof(Action9));

        private void Action10(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10) { }
        private static MethodInfo Action10Info => GetMethodInfo(nameof(Action10));
        
        private void Action11(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11) { }
        private static MethodInfo Action11Info => GetMethodInfo(nameof(Action11));

        private void Action12(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12) { }
        private static MethodInfo Action12Info => GetMethodInfo(nameof(Action12));

        private void Action13(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13) { }
        private static MethodInfo Action13Info => GetMethodInfo(nameof(Action13));

        private void Action14(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14) { }
        private static MethodInfo Action14Info => GetMethodInfo(nameof(Action14));

        private void Action15(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15) { }
        private static MethodInfo Action15Info => GetMethodInfo(nameof(Action15));

        private void Action16(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15, string s16) { }
        private static MethodInfo Action16Info => GetMethodInfo(nameof(Action16));

        private void Action17(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15, string s16, string s17) { }
        private static MethodInfo Action17Info => GetMethodInfo(nameof(Action17));

        private string Func1() => FuncResult;
        private static MethodInfo Func1Info => GetMethodInfo(nameof(Func1));

        private string Func2(string s1) => FuncResult;
        private static MethodInfo Func2Info => GetMethodInfo(nameof(Func2));

        private string Func3(string s1, string s2) => FuncResult;
        private static MethodInfo Func3Info => GetMethodInfo(nameof(Func3));

        private string Func4(string s1, string s2, string s3) => FuncResult;
        private static MethodInfo Func4Info => GetMethodInfo(nameof(Func4));

        private string Func5(string s1, string s2, string s3, string s4) => FuncResult;
        private static MethodInfo Func5Info => GetMethodInfo(nameof(Func5));

        private string Func6(string s1, string s2, string s3, string s4, string s5) => FuncResult;
        private static MethodInfo Func6Info => GetMethodInfo(nameof(Func6));

        private string Func7(string s1, string s2, string s3, string s4, string s5, string s6) => FuncResult;
        private static MethodInfo Func7Info => GetMethodInfo(nameof(Func7));

        private string Func8(string s1, string s2, string s3, string s4, string s5, string s6, string s7) => FuncResult;
        private static MethodInfo Func8Info => GetMethodInfo(nameof(Func8));

        private string Func9(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8) => FuncResult;
        private static MethodInfo Func9Info => GetMethodInfo(nameof(Func9));

        private string Func10(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9) => FuncResult;
        private static MethodInfo Func10Info => GetMethodInfo(nameof(Func10));

        private string Func11(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10) => FuncResult;
        private static MethodInfo Func11Info => GetMethodInfo(nameof(Func11));

        private string Func12(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11) => FuncResult;
        private static MethodInfo Func12Info => GetMethodInfo(nameof(Func12));

        private string Func13(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12) => FuncResult;
        private static MethodInfo Func13Info => GetMethodInfo(nameof(Func13));

        private string Func14(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13) => FuncResult;
        private static MethodInfo Func14Info => GetMethodInfo(nameof(Func14));

        private string Func15(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14) => FuncResult;
        private static MethodInfo Func15Info => GetMethodInfo(nameof(Func15));

        private string Func16(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15) => FuncResult;
        private static MethodInfo Func16Info => GetMethodInfo(nameof(Func16));

        private string Func17(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15, string s16) => FuncResult;
        private static MethodInfo Func17Info => GetMethodInfo(nameof(Func17));

        private string Func18(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15, string s16, string s17) => FuncResult;
        private static MethodInfo Func18Info => GetMethodInfo(nameof(Func18));

        private static MethodInfo GetMethodInfo(string name) =>
            typeof(GetDelegateTypeTests).GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        private static string FuncResult => String.Empty;
    }
}
