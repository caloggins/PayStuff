namespace PayStuffLib.Tests.Core
{
    using AutoMapper;
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Benefits;
    using PayStuffLib.Core;
    using PayStuffLib.Employees;

    public class MappingProfileTests
    {
        [SetUp]
        public void SetUp()
        {
            Mapper.Reset();
            Mapper.Initialize(configuration => configuration.AddProfile(new BenefitsProfile()));
            Mapper.AssertConfigurationIsValid();
        }

        public class WhenGivenAnEmployee : MappingProfileTests
        {
            [Test]
            public void ItShouldReturnTheBenefits()
            {
                var employee = Builder<Employee>
                    .CreateNew().Build();

                var benefitsCost = Mapper.Map<BenefitsCost>(employee);

                var expectedCost = new BenefitsCost
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    NumberOfDependents = employee.NumberOfDependents,
                    CostOfBenefits = 1500m,
                };

                benefitsCost.ShouldBeEquivalentTo(expectedCost);
            }
        }

        public class WhenTheEmployeeHasNoDependents : MappingProfileTests
        {
            [Test]
            public void TheCostShouldBeTheDefault()
            {
                var employee = Builder<Employee>.CreateNew()
                    .With(e => e.NumberOfDependents = 0)
                    .Build();

                var cost = Mapper.Map<BenefitsCost>(employee);

                cost.CostOfBenefits.Should().Be(1000m);
            }
        }

        public class WhenTheEmployeeHasSeveralDependents : MappingProfileTests
        {
            [Test]
            public void TheDependentCostShouldBeAddedToTheDefault()
            {
                var employee = Builder<Employee>.CreateNew()
                    .With(e => e.NumberOfDependents = 2)
                    .Build();

                var cost = Mapper.Map<BenefitsCost>(employee);

                cost.CostOfBenefits.Should().Be(2000m);
            } 
        }

        public class WhenTheEmployeeQualifies : MappingProfileTests
        {
            [Test]
            public void ItShouldGetADiscount()
            {
                var employee = Builder<Employee>.CreateNew()
                    .With(e => e.Name = "Alice")
                    .With(e => e.NumberOfDependents = 2)
                    .Build();

                var cost = Mapper.Map<BenefitsCost>(employee);

                cost.CostOfBenefits.Should().Be(1900m);
            }
        }
    }
}