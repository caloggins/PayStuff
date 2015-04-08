namespace PayStuffLib.Tests.Employees
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Employees;

    public class GetEmployeeByIdTests
    {
        private GetEmployeeById sut;
        
        [SetUp]
        public void SetUp()
        {
            sut = new GetEmployeeById(DatabaseConnection.Create());
        }

        public class WhenThereIsAnEmployee : GetEmployeeByIdTests
        {
            [Test, Integration]
            public void ItShouldReturnTheEmployee()
            {
                var id = Guid.Parse("724775ba-e208-4fd5-85d9-81c09cc4690b");

                var employee = sut.Get(id);

                employee.Should().NotBeNull();
                employee.Name.Should().Be("John");
            }
        }
    }
}