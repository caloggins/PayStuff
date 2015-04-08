namespace PayStuffLib.Tests.Benefits
{
    using System.Data.SqlClient;
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Benefits;

    public class GetAllBenefitsTests
    {
        private GetAllBenefits sut;

        [SetUp]
        public void SetUp()
        {
            sut = new GetAllBenefits(DatabaseConnection.Create());
        }

        public class WhenRun : GetAllBenefitsTests
        {
            [Test, Integration]
            public void ItShouldReturnTheBenefits()
            {
                var costs = sut.Get();

                costs.Should().HaveCount(3);
            }
        }
    }
}