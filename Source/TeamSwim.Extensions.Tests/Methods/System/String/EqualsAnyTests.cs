//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TeamSwim.Extensions.Tests.SystemTests
//{
//    [TestClass]
//    public class EqualsAnyTests : BaseUnitTest
//    {
//        [TestMethod]
//        public void False_Returned_When_Strings_Are_Null()
//        {
//            var value = Utility.RandomString();
//            var result = value.EqualsAny(StringComparison.CurrentCulture, null);

//            Assert.IsFalse(result);
//        }

//        [TestMethod]
//        public void False_Returned_When_Sequence_Does_Not_Contain_String()
//        {
//            var strings = Pseudo.Pseudo.String().Exclude(null).GetList();
//            var value = Pseudo.Pseudo.String().ExcludeList(strings).Get();

//            var result = value.EqualsAny(StringComparison.CurrentCulture, strings.ToArray());

//            Assert.IsFalse(result);
//        }

//        [TestMethod]
//        public void True_Returned_When_Sequence_Contains_String()
//        {
//            var strings = Pseudo.Pseudo.String().Exclude(null).NoLessThan(10).GetList();
//            var value = strings.First();

//            var result = value.EqualsAny(StringComparison.CurrentCulture, strings.ToArray());

//            Assert.IsTrue(result);
//        }
//    }
//}
