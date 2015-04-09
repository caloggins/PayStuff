namespace PayStuffLib.Tests.Dependents
{
    using System;
    using Data;
    using FakeItEasy;
    using FizzWare.NBuilder;
    using NUnit.Framework;
    using PayStuffLib.Core;
    using PayStuffLib.Dependents;

    public class CreateDependentTests
    {
        private CreateDependent sut;
        private SavePerson savePerson;
        private IBus bus;

        [SetUp]
        public virtual void SetUp()
        {
            savePerson = A.Fake<SavePerson>();
            bus = A.Fake<IBus>();
            sut = new CreateDependent(savePerson, bus);
        }

        public class WhenADependentIsCreated : CreateDependentTests
        {
            private Dependent dependent;
            private Guid employeeId;

            [SetUp]
            public override void SetUp()
            {
                base.SetUp();

                dependent = Builder<Dependent>.CreateNew()
                    .Build();
                employeeId = Guid.NewGuid();                
            }

            [Test]
            public void ItShouldSaveTheNewPerson()
            {
                sut.Run(employeeId, dependent);

                A.CallTo(() => savePerson.Run(employeeId, dependent.Name))
                    .MustHaveHappened();
            }

            [Test]
            public void ItShouldNotifyADependentWasCreated()
            {
                var dependentId = Guid.NewGuid();

                sut.Run(employeeId, dependent);

                var expected = new DependentCreated { Id = dependentId };
                A.CallTo(() => bus.Publish(A<DependentCreated>.That.IsEqualTo(expected)))
                    .MustHaveHappened();
            }
        }
    }

}