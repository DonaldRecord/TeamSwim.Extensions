using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamSwim;

namespace System
{
    [TestClass]
    public class StaticAnalysisTests
    {
        [TestMethod]
        public void All_Public_Extension_Methods_Have_Public_API_Attribute()
        {
            var failingMethods = TeamSwimExtensions.Assembly.GetTypes()
                .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static))
                .Where(mi => mi.GetCustomAttribute<PublicAPIAttribute>() == null)
                .ToList();

            if (failingMethods.Any())
            {
                var msg = "The following methods do not have PublicAPI attributes: " +
                          $"{String.Join(Environment.NewLine, failingMethods.Select(m => WriteMethodLine(m.DeclaringType, m.Name)))}";
                Assert.Fail(msg);
            }
        }

        private static string WriteMethodLine(Type declaringType, string memberName) => $"{declaringType}.{memberName}";

        // TODO: GET THIS WORKING
        //[TestMethod]
        //public void All_Enum_Members_Have_Descriptions()
        //{
        //    var offenders = TeamSwimExtensions.Assembly.GetTypes()
        //        .Where(t => t.IsEnum)
        //        .SelectMany(t => t.GetFields(BindingFlags.Public | BindingFlags.Instance))
        //        .Where(m => m.GetCustomAttribute<ComponentModel.DescriptionAttribute>() == null)
        //        .Where(m => m.Name != "value__")
        //        .ToList();

        //    if (offenders.Any())
        //    {
        //        var msg = $"The following enums do not have description attributes: " +
        //                  $"{String.Join(Environment.NewLine, offenders.Select(m => WriteMethodLine(m.DeclaringType, m.Name)))}";
        //        Assert.Fail(msg);
        //    }
        //}
    }
}
