namespace PayStuffLib.Benefits
{
    using System.Collections.Generic;
    using System.Data;
    using Core;
    using DapperExtensions;
    using Data;

    public class GetAllBenefits : NoParameterQuery<IEnumerable<BenefitsCost>>
    {
        private readonly IDbConnection connection;

        public GetAllBenefits(IDbConnection connection)
        {
            this.connection = connection;
        }

        public override IEnumerable<BenefitsCost> Get()
        {
            var costs = connection.GetList<BenefitsCost>();
            return costs;
        }
    }
}