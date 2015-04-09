namespace PayStuffLib.Employees
{
    using System;
    using System.Data;
    using Benefits;
    using Core;
    using DapperExtensions;

    public class DeleteEmployee : Command
    {
        private readonly IDbConnection connection;

        public DeleteEmployee(IDbConnection connection)
        {
            this.connection = connection;
        }

        public virtual void Run(Guid employeeId)
        {
            var deleted = connection.Delete<Employee>(new {Id = employeeId});

            if (deleted)
                connection.Delete<BenefitsCost>(new {EmployeeId = employeeId});
        }
    }
}