// ReSharper disable PossibleNullReferenceException
namespace PayStuffWeb.Tests.Controllers
{
    using System;
    using System.Web.Http.Results;
    using FakeItEasy;
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Dependents;
    using PayStuffLib.Employees;
    using PayStuffWeb.Controllers;

    public class DependentsControllerTests
    {
        private DependentsController sut;
        private CreateDependent createDependent;

        [SetUp]
        public virtual void SetUp()
        {
            createDependent = A.Fake<CreateDependent>();
            sut = new DependentsController(createDependent);
        }

        public class AddingDependents : DependentsControllerTests
        {
            private Dependent dependent;
            private Guid employeeId;

            public override void SetUp()
            {
                base.SetUp();

                employeeId = Guid.NewGuid();
                dependent = Builder<Dependent>.CreateNew().Build();
            }

            [Test]
            public void ItShouldReturnTheLocation()
            {
                var result = sut.Post(employeeId, dependent) as CreatedAtRouteNegotiatedContentResult<Dependent>;

                result.Should().NotBeNull();
                result.RouteName.Should().Be("Dependents");
                result.Content.Should().Be(dependent);
                result.RouteValues["id"].Should().Be(dependent.Id);
                result.RouteValues["controller"].Should().Be("dependents");
            }

            [Test]
            public void ItShouldCreateTheDependent()
            {
                sut.Post(employeeId, dependent);

                A.CallTo(() => createDependent.Run(employeeId, dependent))
                    .MustHaveHappened();
            }
        }
    }
}