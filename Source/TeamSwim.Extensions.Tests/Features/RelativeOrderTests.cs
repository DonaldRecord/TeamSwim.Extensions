using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamSwim.Features.RelativeOrdering;

namespace TeamSwim.Features
{
    [TestClass]
    public class RelativeOrderTests
    {
        [TestMethod]
        public void Returns_Expected_Order_With_Only_Before_Instructions_In_Reverse_Order()
        {
            var actual = new INumberProvider[]
            {
                new N5Provider(),
                new N4Provider(b => b.Before<N5Provider>()),
                new N3Provider(b => b.Before<N4Provider>()),
                new N2Provider(b => b.Before<N3Provider>()),
                new N1Provider(b => b.Before<N2Provider>()),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[2], typeof(N3Provider));
            Assert.IsInstanceOfType(actual[3], typeof(N4Provider));
            Assert.IsInstanceOfType(actual[4], typeof(N5Provider));
        }

        [TestMethod]
        public void Returns_Expected_Order_With_Only_After_Instructions_In_Reverse_Order()
        {
            var actual = new INumberProvider[]
            {
                new N5Provider(b => b.After<N4Provider>()),
                new N4Provider(b => b.After<N3Provider>()),
                new N3Provider(b => b.After<N2Provider>()),
                new N2Provider(b => b.After<N1Provider>()),
                new N1Provider(),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[2], typeof(N3Provider));
            Assert.IsInstanceOfType(actual[3], typeof(N4Provider));
            Assert.IsInstanceOfType(actual[4], typeof(N5Provider));
        }

        [TestMethod]
        public void Returns_Expected_Preserved_Order()
        {
            var actual = new INumberProvider[]
            {
                new N1Provider(),
                new N2Provider(b => b.After<N1Provider>().Before<N3Provider>()),
                new N3Provider(),
                new N4Provider(b => b.After<N3Provider>().Before<N5Provider>()),
                new N5Provider(),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[2], typeof(N3Provider));
            Assert.IsInstanceOfType(actual[3], typeof(N4Provider));
            Assert.IsInstanceOfType(actual[4], typeof(N5Provider));
        }


        [TestMethod]
        public void Returns_Expected_Order_With_Before_And_After_Flags_1()
        {
            var actual = new INumberProvider[]
            {
                new N3Provider(),
                new N2Provider(b => b.After<N1Provider>().Before<N3Provider>()),
                new N1Provider(),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[2], typeof(N3Provider));
        }

        [TestMethod]
        public void Returns_Expected_Empty()
        {
            var actual = new INumberProvider[] { }.WithRelativeOrdering().ToList();

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Returns_Expected_One_Without_Instruction()
        {
            var actual = new INumberProvider[] { new N4Provider() }.WithRelativeOrdering().ToList();

            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void Returns_Expected_One_With_Instruction()
        {
            var actual = new INumberProvider[] { new N4Provider(b => b.Last(true)) }.WithRelativeOrdering().ToList();

            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void Puts_First_Ahead_Of_No_Instructions()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(),
                new N1Provider(b => b.First())
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        public void Returns_Expected_Order_With_Ordinals()
        {
            var actual = new INumberProvider[]
            {
                new N5Provider(b => b.WithOrdinal(5)),
                new N4Provider(b => b.WithOrdinal(4)),
                new N3Provider(b => b.WithOrdinal(3)),
                new N2Provider(b => b.WithOrdinal(2)),
                new N1Provider(b => b.WithOrdinal(1)),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[2], typeof(N3Provider));
            Assert.IsInstanceOfType(actual[3], typeof(N4Provider));
            Assert.IsInstanceOfType(actual[4], typeof(N5Provider));
        }

        [TestMethod]
        public void Equal_Ordinals_Preserve_Order()
        {
            var actual = new INumberProvider[]
            {
                new N5Provider(b => b.WithOrdinal(5)),
                new N4Provider(b => b.WithOrdinal(5)),
                new N3Provider(b => b.WithOrdinal(5)),
                new N2Provider(b => b.WithOrdinal(5)),
                new N1Provider(b => b.WithOrdinal(5)),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N5Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N4Provider));
            Assert.IsInstanceOfType(actual[2], typeof(N3Provider));
            Assert.IsInstanceOfType(actual[3], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[4], typeof(N1Provider));
        }

        [TestMethod]
        public void Multiple_Instances_Follow_Their_Own_Instructions()
        {
            var actual = new INumberProvider[]
            {
                new N5Provider(b => b.WithOrdinal(5)),
                new N5Provider(b => b.WithOrdinal(10)),
                new N4Provider(b => b.WithOrdinal(4)),
                new N4Provider(b => b.WithOrdinal(9)),
                new N3Provider(b => b.WithOrdinal(3)),
                new N3Provider(b => b.WithOrdinal(8)),
                new N2Provider(b => b.WithOrdinal(2)),
                new N2Provider(b => b.WithOrdinal(7)),
                new N1Provider(b => b.WithOrdinal(1)),
                new N1Provider(b => b.WithOrdinal(6)),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[2], typeof(N3Provider));
            Assert.IsInstanceOfType(actual[3], typeof(N4Provider));
            Assert.IsInstanceOfType(actual[4], typeof(N5Provider));
            Assert.IsInstanceOfType(actual[5], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[6], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[7], typeof(N3Provider));
            Assert.IsInstanceOfType(actual[8], typeof(N4Provider));
            Assert.IsInstanceOfType(actual[9], typeof(N5Provider));
        }

        [TestMethod]
        [ExpectedException(typeof(RelativeOrderException))]
        public void Multiple_Force_First_Flags_Throw_Exception()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.ForceFirst()),
                new N1Provider(b => b.ForceFirst()),
            }.WithRelativeOrdering().ToList();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(RelativeOrderException))]
        public void Multiple_Force_First_Overload_Flags_Throw_Exception()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.First(true)),
                new N1Provider(b => b.First(true)),
            }.WithRelativeOrdering().ToList();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(RelativeOrderException))]
        public void Multiple_Force_Last_Flags_Throw_Exception()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.ForceLast()),
                new N1Provider(b => b.ForceLast()),
            }.WithRelativeOrdering().ToList();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(RelativeOrderException))]
        public void Multiple_Force_Last_Overload_Flags_Throw_Exception()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.Last(true)),
                new N1Provider(b => b.Last(true)),
            }.WithRelativeOrdering().ToList();

            Assert.Fail();
        }

        [TestMethod]
        public void First_Flag_Force_Expected_Result()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(),
                new N1Provider(b => b.First(true)),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        public void First_Flag_Force_Overload_Expected_Result()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(),
                new N1Provider(b => b.ForceFirst()),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        public void First_Flag_Expected_Result()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(),
                new N1Provider(b => b.First()),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        public void Multiple_First_Flag_Preserves_Order()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.First()),
                new N1Provider(b => b.First()),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N1Provider));
        }

        [TestMethod]
        public void Last_Flag_Force_Expected_Result()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.Last(true)),
                new N1Provider(),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        public void Last_Flag_Force_Overload_Expected_Result()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.ForceLast()),
                new N1Provider(),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        public void Last_Flag_Expected_Result()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.Last()),
                new N1Provider(),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        public void Multiple_Last_Flag_Preserves_Order()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.Last()),
                new N1Provider(b => b.Last()),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N1Provider));
        }

        [TestMethod]
        [ExpectedException(typeof(RelativeOrderException))]
        public void Circular_Before_Instruction_Throws_Exception()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.Before<N1Provider>()),
                new N1Provider(b => b.Before<N2Provider>()),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        [ExpectedException(typeof(RelativeOrderException))]
        public void Circular_After_Instruction_Throws_Exception()
        {
            var actual = new INumberProvider[]
            {
                new N2Provider(b => b.After<N1Provider>()),
                new N1Provider(b => b.After<N2Provider>()),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N2Provider));
        }

        [TestMethod]
        public void No_Instructions_Preserves_Order()
        {
            var actual = new INumberProvider[]
            {
                new N6Provider(),
                new N5Provider(),
                new N4Provider(),
                new N2Provider(),
                new N3Provider(),
                new N1Provider(),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N6Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N5Provider));
            Assert.IsInstanceOfType(actual[2], typeof(N4Provider));
            Assert.IsInstanceOfType(actual[3], typeof(N2Provider));
            Assert.IsInstanceOfType(actual[4], typeof(N3Provider));
            Assert.IsInstanceOfType(actual[5], typeof(N1Provider));
        }

        [TestMethod]
        public void First_Inserted_Before_No_Instruction()
        {
            var actual = new INumberProvider[]
            {
                new N6Provider(),
                new N1Provider(b => b.First()),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N1Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N6Provider));
        }

        [TestMethod]
        public void Last_Inserted_After_No_Instruction()
        {
            var actual = new INumberProvider[]
            {
                new N1Provider(b => b.Last()),
                new N6Provider(),
            }.WithRelativeOrdering().ToList();

            Assert.IsInstanceOfType(actual[0], typeof(N6Provider));
            Assert.IsInstanceOfType(actual[1], typeof(N1Provider));
        }

        interface INumberProvider
        {
            int Value { get; }
        }

        abstract class NumberProviderTestBase : INumberProvider, IRelativeOrderEnabled<INumberProvider>
        {
            protected NumberProviderTestBase(Action<RelativeOrderInstructionBuilder<INumberProvider>> setup = null)
                => Setup = setup;

            public abstract int Value { get; }
            public Action<RelativeOrderInstructionBuilder<INumberProvider>> Setup { get; }
        }


        class N1Provider : NumberProviderTestBase
        {
            public override int Value => 1;
            public N1Provider(Action<RelativeOrderInstructionBuilder<INumberProvider>> setup = null) : base(setup) { }
        }

        class N2Provider : NumberProviderTestBase
        {
            public override int Value => 2;
            public N2Provider(Action<RelativeOrderInstructionBuilder<INumberProvider>> setup = null) : base(setup) { }
        }

        class N3Provider : NumberProviderTestBase
        {
            public override int Value => 3;
            public N3Provider(Action<RelativeOrderInstructionBuilder<INumberProvider>> setup = null) : base(setup) { }
        }

        class N4Provider : NumberProviderTestBase
        {
            public override int Value => 4;
            public N4Provider(Action<RelativeOrderInstructionBuilder<INumberProvider>> setup = null) : base(setup) { }
        }

        class N5Provider : NumberProviderTestBase
        {
            public override int Value => 5;
            public N5Provider(Action<RelativeOrderInstructionBuilder<INumberProvider>> setup = null) : base(setup) { }
        }

        class N6Provider : INumberProvider
        {
            public int Value => 6;
        }
    }
}
