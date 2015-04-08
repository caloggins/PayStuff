// ReSharper disable PossibleNullReferenceException
namespace PayStuffWeb.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http.Results;
    using FakeItEasy;
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Benefits;
    using PayStuffWeb.Controllers;

    public class BenefitsControllersTests
    {
        private BenefitsController sut;
        private GetAllBenefits getAllBenefits;

        [SetUp]
        public void SetUp()
        {
            getAllBenefits = A.Fake<GetAllBenefits>();
            sut = new BenefitsController(getAllBenefits);
        }

        public class WhenThereAreEmployees : BenefitsControllersTests
        {
            [Test]
            public void ItShouldReturnTheBenefits()
            {
                var employees = Builder<BenefitsCost>.CreateListOfSize(5)
                    .Build();
                A.CallTo(() => getAllBenefits.Get())
                    .Returns(employees);

                var result = sut.Get() as OkNegotiatedContentResult<IEnumerable<BenefitsCost>>;

                result.Should().NotBeNull();
                result.Content.Should().BeEquivalentTo(employees);
            }
        }
    }
}