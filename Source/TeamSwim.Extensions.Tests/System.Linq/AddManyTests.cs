using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Linq
{
    [TestClass]
    public class AddManyTests : BaseUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception()
        {
            var scope = new Scope {Source = null};
            scope.ExecuteTest();
        }

        [TestMethod]
        public void Null_New_Elements_Does_Not_Affect_Source()
        {
            var scope = new Scope {NewElements = null};
            var expected = scope.Source.Count;
            scope.ExecuteTest();

            Assert.AreEqual(expected, scope.Source.Count);
        }

        [TestMethod]
        public void Null_Elements_Are_Not_Ignored()
        {
            var scope = new Scope().ExtendNewElements(null).ExtendNewElements(null).ExtendNewElements(Utility.RandomString());
            var originalDestCount = scope.Source.Count;
            var newElementCount = scope.NewElements.Count;

            scope.ExecuteTest(false);

            var expected = originalDestCount + newElementCount;
            Assert.AreEqual(expected, scope.Source.Count);
        }

        [TestMethod]
        public void Null_Elements_Are_Not_Ignored_By_Default()
        {
            var scope = new Scope().ExtendNewElements(null).ExtendNewElements(null).ExtendNewElements(Utility.RandomString());
            var originalDestCount = scope.Source.Count;
            var newElementCount = scope.NewElements.Count;

            scope.ExecuteTest();

            var expected = originalDestCount + newElementCount;
            Assert.AreEqual(expected, scope.Source.Count);
        }

        public void Null_Elements_Are_Ignored()
        {
            var scope = new Scope().ExtendNewElements(null).ExtendNewElements(null).ExtendNewElements(Utility.RandomString());
            var originalDestCount = scope.Source.Count;
            var newElementCount = scope.NewElements.Count(e => e != null);

            scope.ExecuteTest(true);

            var expected = originalDestCount + newElementCount;
            Assert.AreEqual(expected, scope.Source.Count);

        }

        class Scope
        {
            public Scope()
            {
                
            }

            public void ExecuteTest(bool? excludeNullElements = null)
            {
                if (excludeNullElements.HasValue)
                    Source.AddMany(NewElements, excludeNullElements.Value);
                else
                    Source.AddMany(NewElements);
            } 

            public List<string> Source { get; set; } = new List<string>
            {
                Utility.RandomString(),
                Utility.RandomString(),
                Utility.RandomString()
            };

            public List<string> NewElements { get; set; } = new List<string>
            {
                Utility.RandomString(),
                Utility.RandomString()
            };

            public Scope ExtendNewElements(string s)
            {
                NewElements.Add(s);
                return this;
            }
        }
    }
}
