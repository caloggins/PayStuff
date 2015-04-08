namespace PayStuffLib.Benefits
{
    using System;
    using System.Data;
    using System.Linq;
    using Core;
    using DapperExtensions;

    public class GetBenefitsByEmployee : Query<Guid, BenefitsCost>
    {
        private readonly IDbConnection connection;

        public GetBenefitsByEmployee(IDbConnection connection)
        {
            this.connection = connection;
        }

        public override BenefitsCost Get(Guid id)
        {
            return connection.GetList<BenefitsCost>(new {EmployeeId = id})
                .FirstOrDefault();
        }
    }
}