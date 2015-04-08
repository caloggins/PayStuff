namespace PayStuffLib.Core
{
    using AutoMapper;
    using Benefits;
    using Employees;

    public class BenefitsProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Employee, BenefitsCost>()
                .ForMember(d => d.Id, e => e.Ignore())
                .ForMember(d => d.EmployeeId, e => e.MapFrom(s => s.Id))
                .ForMember(d => d.EmployeeName, e => e.MapFrom(s => s.Name))
                .ForMember(d => d.CostOfBenefits, e => e.ResolveUsing<BenefitsCostCalculator>());
        }
    }
}