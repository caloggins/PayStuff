namespace PayStuffLib.Employees
{
    using System.Collections.Generic;
    using System.Data;
    using Core;
    using DapperExtensions;
    using Data;
    using FizzWare.NBuilder;

    public class GetAllEmployees : NoParameterQuery<IEnumerable<Employee>>
    {
        private readonly IDbConnection connection;

        public GetAllEmployees(IDbConnection connection)
        {
            this.connection = connection;
        }

        public override IEnumerable<Employee> Get()
        {
            return connection.GetList<Employee>();
        }
    }
}