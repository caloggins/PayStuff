namespace PayStuffLib.Employees
{
    using System;
    using System.Data;
    using AutoMapper;
    using Benefits;
    using Core;
    using DapperExtensions;

    public class CreateEmployee : Command
    {
        private readonly IDbConnection connection;
        private readonly IMappingEngine engine;

        public CreateEmployee(IDbConnection connection, IMappingEngine engine)
        {
            this.connection = connection;
            this.engine = engine;
        }

        public virtual void Run(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            connection.Insert(employee);

            var benefits = engine.Map<Employee, BenefitsCost>(employee);
           
            connection.Insert(benefits);
        }
    }
}