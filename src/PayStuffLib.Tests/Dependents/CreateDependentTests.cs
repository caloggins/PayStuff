namespace PayStuffLib.Tests.Dependents
{
    using System;
    using FakeItEasy;
    using FizzWare.NBuilder;
    using NUnit.Framework;
    using PayStuffLib.Core;
    using Data;
    using PayStuffLib.Dependents;

    public class CreateDependentTests
    {
        private CreateDependent sut;
        private SavePerson savePerson;
        private IBus bus;
        private Func<Guid> idGenerator;

        [SetUp]
        public virtual void SetUp()
        {
            savePerson = A.Fake<SavePerson>();
            bus = A.Fake<IBus>();
            idGenerator = A.Fake<Func<Guid>>();
            sut = new CreateDependent(idGenerator, savePerson, bus);
        }

        public class WhenADependentIsCreated : CreateDependentTests
        {
            private Dependent dependent;
            private Guid employeeId;
            private Guid dependentId;

            [SetUp]
            public override void SetUp()
            {
                base.SetUp();

                dependent = Builder<Dependent>.CreateNew()
                    .Build();

                dependentId = Guid.Parse("8B8F56DF-3B87-4EC5-BA46-DDDA0F9A0CDA");
                A.CallTo(() => idGenerator.Invoke())
                    .Returns(dependentId);
                
                employeeId = Guid.Parse("410A2D1D-677C-4C55-A59C-F729C2D24CB5");
            }

            [Test]
            public void ItShouldSaveTheNewPerson()
            {
                sut.Run(employeeId, dependent);

                A.CallTo(() => savePerson.Run(employeeId, dependentId, dependent.Name))
                    .MustHaveHappened();
            }

            [Test]
            public void ItShouldNotifyADependentWasCreated()
            {
                var expected = Builder<DependentCreated>
                    .CreateNew().With(created => created.Id = dependentId)
                    .Build();
                sut.Message = () => expected;

                sut.Run(employeeId, dependent);

                A.CallTo(() => bus.Publish(expected))
                    .MustHaveHappened();
            }
        }
    }

}