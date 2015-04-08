namespace PayStuffLib.Tests.Employees
{
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Employees;

    public class GetAllEmployeesTests
    {
        private GetAllEmployees sut;

        [SetUp]
        public void SetUp()
        {
            sut = new GetAllEmployees(DatabaseConnection.Create());
        }

        public class WhenRan : GetAllEmployeesTests
        {
            [Test, Integration]
            public void ItShouldReturnTheEmployees()
            {
                sut.Get().Should()
                    .HaveCount(3);
            }
        }
    }
}