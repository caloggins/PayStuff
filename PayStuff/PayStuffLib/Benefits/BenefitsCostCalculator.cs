namespace PayStuffLib.Benefits
{
    using AutoMapper;
    using Employees;

    public class BenefitsCostCalculator : ValueResolver<Employee, decimal>
    {
        protected override decimal ResolveCore(Employee source)
        {
            var costOfDependents = source.NumberOfDependents * 500m;

            var employeeCost = source.Name.StartsWith("A") ? 900m : 1000m;

            var total = employeeCost + costOfDependents;

            return total;
        }
    }
}