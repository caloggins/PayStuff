namespace PayStuffLib.Tests.Employees
{
    using System;
    using System.Data;
    using DapperExtensions;
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Employees;

    public class DeleteEmployeeTests
    {
        private DeleteEmployee sut;

        public class WhenThereIsAnEmployee : DeleteEmployeeTests
        {
            private readonly Guid employeeId = Guid.NewGuid();
            private readonly IDbConnection connection = DatabaseConnection.Create();

            [Test]
            public void ItShouldBeDeleted()
            {
                var employee = Builder<Employee>.CreateNew()
                    .With(e => e.Id = employeeId)
                    .Build();

                connection.Insert(employee);

                sut = new DeleteEmployee(connection);
                sut.Run(employee.Id);

                var result = connection.Get<Employee>(new { employee.Id });

                if (result != null)
                    connection.Delete(result);
                connection.Dispose();

                result.Should().BeNull();
            }
        }
    }
}