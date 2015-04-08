namespace PayStuffLib.Benefits
{
    using System;
    using DapperExtensions.Mapper;

    public class BenefitsCost
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int NumberOfDependents { get; set; }
        public decimal CostOfBenefits { get; set; }
    }

    public sealed class BenefitsCostMap : ClassMapper<BenefitsCost>
    {
        public BenefitsCostMap()
        {
            Table("BenefitsCosts");

            Map(cost => cost.Id).Key(KeyType.Guid);
            Map(cost => cost.CostOfBenefits).Column("Cost");
            AutoMap();
        }
    }
}