using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    [TestClass]
    public class AnalysisTests
    {
        [TestMethod]
        public void All_Public_Extension_Methods_Have_Public_API_Attribute()
        {
            var assembly = Assembly.GetAssembly(typeof(StringExt));
            var failingMethods = assembly.GetTypes()
                .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static))
                .Where(mi => mi.GetCustomAttribute<PublicAPIAttribute>() == null)
                .ToList();

            if (failingMethods.Any())
            {
                var msg = $"The following methods do not have PublicAPI attributes: " +
                          $"{String.Join(Environment.NewLine, failingMethods.Select(WriteMethodLine))}";
                Assert.Fail(msg);
            }
        }

        private static string WriteMethodLine(MethodInfo method) => $"{method.DeclaringType}.{method.Name}";
    }
}
