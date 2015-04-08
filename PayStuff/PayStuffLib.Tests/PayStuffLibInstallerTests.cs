namespace PayStuffLib.Tests
{
    using System.Data;
    using AutoMapper;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using FakeItEasy;
    using NUnit.Framework;

    public class PayStuffLibInstallerTests
    {
        private IWindsorContainer container;
        private IWindsorInstaller installer;

        [SetUp]
        public void SetUp()
        {
            container = new WindsorContainer();

            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<IDbConnection>().UsingFactoryMethod(A.Fake<IDbConnection>).LifestyleTransient(),
                Component.For<IMappingEngine>().UsingFactoryMethod(() => Mapper.Engine)
                );

            installer = new PayStuffLibInstaller();
            container.Install(installer);
        }

        public class WhenTheInstallerIsUsed : PayStuffLibInstallerTests
        {
            [Test]
            public void ItShouldHaveAValidConfig()
            {
                container.AssertIsValid();
            }
        }
    }
}