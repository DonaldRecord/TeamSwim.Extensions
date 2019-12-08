//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TeamSwim.Extensions.Tests.System.HolidayTests
//{
//    public sealed class CalendarHolidayTests : BaseUnitTest
//    {
//        internal const string CalendarHolidayTest = "System.CalendarHoliday";
        
//        private DateTime Christmas2016 => new DateTime(2016, 12, 25); //SUNDAY
//        private DateTime Christmas2017 => new DateTime(2017, 12, 25); //not a weekend
//        private DateTime Christmas2018 => new DateTime(2018, 12, 25); //not a weekend

//        //[TestMethod]
//        //[TestCategory(TargetProject), TestCategory(CalendarHolidayTest), TestCategory(TestTraits.ExtensionMethod)]
//        //public void Is_Today_Returns_True_For_Known_Non_Weekend_Holiday_Without_Adjustment_Flag()
//        //{
//        //    var result = Holiday.IsHoliday(Christmas2017, out var xmas, false);

//        //    Assert.IsTrue(result);
//        //    Assert.IsNotNull(xmas);
//        //    Assert.AreEqual(Holiday.Christmas.Name, xmas.Name);
//        //}

//        //[TestMethod]
//        //[TestCategory(TargetProject), TestCategory(CalendarHolidayTest), TestCategory(TestTraits.ExtensionMethod)]
//        //public void Is_Today_Returns_True_For_Known_Non_Weekend_Holiday_With_Adjustment_Flag()
//        //{
//        //    var result = Holiday.IsHoliday(Christmas2017, out var xmas, true);

//        //    Assert.IsTrue(result);
//        //    Assert.IsNotNull(xmas);
//        //    Assert.AreEqual(Holiday.Christmas.Name, xmas.Name);
//        //}
//    }
//}
