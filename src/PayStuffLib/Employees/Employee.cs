namespace PayStuffLib.Employees
{
    using System;
    using DapperExtensions.Mapper;

    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfDependents { get; set; }
    }

    public sealed class EmployeeMap : ClassMapper<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");

            Map(employee => employee.Id).Key(KeyType.Guid);
            Map(employee => employee.Name).Column("EmployeeName");

            AutoMap();
        }
    }
}               