using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.System.Linq
{
    [TestClass]
    public class MutateTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception_Overload1()
        {
            var scope = new Scope {Source = null}.ExecuteOverload1();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Mutation_Throws_Execption_Overload1()
        {
            var scope = new Scope {Mutation1 = null}.ExecuteOverload1();
        }

        

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Source_Throws_Exception_Overload2()
        {
            var scope = new Scope {Source = null}.ExecuteOverload2();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Mutation_Throws_Execption_Overload2()
        {
            var scope = new Scope {Mutation2 = null}.ExecuteOverload2();
        }

        class Scope
        {
            public List<Entity> Source { get; set; } = new List<Entity>
            {
                new Entity(),
                new Entity(),
                new Entity()
            };

            public Action<Entity> Mutation1 { get; set; } = e => { };
            public Func<Entity, bool> Predicate1 { get; set; } = _ => true;
            public Action<Entity, int> Mutation2 { get; set; } = (e, i) => { };
            public Func<Entity, int, bool> Predicate2 { get; set; } = (_, __) => true;

            public IEnumerable<Entity> ExecuteOverload1() => Source.Mutate(Mutation1, Predicate1);
            public IEnumerable<Entity> ExecuteOverload2() => Source.Mutate(Mutation2, Predicate2);

            public class Entity
            {
                public string StringProperty { get; set; } = Utility.RandomString();
            }
        }
    }
}
