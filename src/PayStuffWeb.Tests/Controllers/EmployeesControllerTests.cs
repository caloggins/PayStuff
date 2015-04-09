// ReSharper disable PossibleNullReferenceException
namespace PayStuffWeb.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Results;
    using FakeItEasy;
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Benefits;
    using PayStuffLib.Core;
    using PayStuffLib.Data;
    using PayStuffLib.Employees;
    using PayStuffWeb.Controllers;

    public class EmployeesControllerTests
    {
        private EmployeesController sut;
        private IQueryFactory queryFactory;
        private DeleteEmployee deleteEmployee;
        private CreateEmployee createEmployee;

        [SetUp]
        public virtual void SetUp()
        {
            deleteEmployee = A.Fake<DeleteEmployee>();
            createEmployee = A.Fake<CreateEmployee>();

            queryFactory = A.Fake<IQueryFactory>();

            sut = new EmployeesController(queryFactory,
                createEmployee,
                deleteEmployee);
        }

        public class GettingEmployees : EmployeesControllerTests
        {
            private GetEmployeeById getEmployeeById;
            private GetAllEmployees getAllEmployees;

            public override void SetUp()
            {
                base.SetUp();

                getAllEmployees = A.Fake<GetAllEmployees>();
                getEmployeeById = A.Fake<GetEmployeeById>();

                A.CallTo(() => queryFactory.Create<GetAllEmployees>())
                    .Returns(getAllEmployees);
                A.CallTo(() => queryFactory.Create<GetEmployeeById>())
                    .Returns(getEmployeeById);
            }

            [Test]
            public void ItShouldReturnAListOfEmployees()
            {
                var result = sut.Get() as OkNegotiatedContentResult<IEnumerable<Employee>>;

                result.Content.Should().BeAssignableTo<IEnumerable<Employee>>();
            }

            [Test]
            public void ItShouldReturnAllEmployees()
            {
                var employees = Builder<Employee>.CreateListOfSize(5)
                    .Build();
                A.CallTo(() => getAllEmployees.Get())
                    .Returns(employees);

                var result = sut.Get() as OkNegotiatedContentResult<IEnumerable<Employee>>;
                
                result.Content.Should().BeEquivalentTo(employees);
            }

            [Test]
            public void ItShouldReturnSpecificEmployees()
            {
                var employeeId = Guid.NewGuid();
                var expectedEmployee = new Employee
                {
                    Id = employeeId,
                    Name = "joe bagodonuts",
                };
                A.CallTo(() => getEmployeeById.Get(employeeId))
                    .Returns(expectedEmployee);

                var result = sut.Get(employeeId)
                    as OkNegotiatedContentResult<Employee>;

                result.Content.Should().Be(expectedEmployee);
            }
        }

        public class AddingEmployees : EmployeesControllerTests
        {
            private readonly Employee employee = A.Fake<Employee>();

            [Test]
            public void ItShouldReturnTheCreatedEmployee()
            {
                var actionResult = sut.Post(employee) as CreatedAtRouteNegotiatedContentResult<Employee>;

                actionResult.Content.Should().Be(employee);
            }

            [Test]
            public void ItShouldReturnTheCorrectLocation()
            {
                var actionResult = sut.Post(employee) as CreatedAtRouteNegotiatedContentResult<Employee>;

                actionResult.RouteName.Should().Be("DefaultApi");
                actionResult.Content.Should().Be(employee);
                actionResult.RouteValues["id"].Should().Be(employee.Id);
                actionResult.RouteValues["controller"].Should().Be("employees");
            }

            [Test]
            public void ItShouldActuallySaveTheClient()
            {
                sut.Post(employee);

                A.CallTo(() => createEmployee.Run(employee))
                    .MustHaveHappened();
            }
        }

        public class DeletingEmployees : EmployeesControllerTests
        {
            private readonly Guid employeeId = Guid.NewGuid();

            [Test]
            public void ItShouldReturnAnOk()
            {
                var result = sut.Delete(employeeId);

                result.Should().BeOfType<OkResult>();
            }

            [Test]
            public void ItShouldDeleteTheEmployee()
            {
                sut.Delete(employeeId);

                A.CallTo(() => deleteEmployee.Run(employeeId))
                    .MustHaveHappened();
            }
        }

        public class GettingEmployeeBenefits : EmployeesControllerTests
        {
            private readonly Guid employeeId = Guid.NewGuid();

            [Test]
            public void ItShouldReturnEmployeeBenefits()
            {
                var query = A.Fake<GetBenefitsByEmployee>();
                A.CallTo(() => queryFactory.Create<GetBenefitsByEmployee>())
                    .Returns(query);
                var cost = Builder<BenefitsCost>.CreateNew().Build();
                A.CallTo(() => query.Get(employeeId))
                    .Returns(cost);

                var result = sut.GetBenefits(employeeId) as OkNegotiatedContentResult<BenefitsCost>;

                result.Content.Should().Be(cost);
            }
        }
    }
}