namespace PayStuffLib.Employees
{
    using System;
    using System.Data;
    using Core;
    using DapperExtensions;
    using Data;

    public class GetEmployeeById : Query<Guid, Employee>
    {
        private readonly IDbConnection connection;

        public GetEmployeeById(IDbConnection connection)
        {
            this.connection = connection;
        }

        public override Employee Get(Guid id)
        {
            var employee = connection.Get<Employee>(new {Id = id});
            return employee;
        }
    }
}