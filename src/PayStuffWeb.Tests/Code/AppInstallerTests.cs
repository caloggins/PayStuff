namespace PayStuffWeb.Tests.Code
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using NUnit.Framework;
    using PayStuffWeb.Code;

    public class AppInstallerTests
    {
        private IWindsorContainer container;
        private IWindsorInstaller installer;

        [SetUp]
        public void SetUp()
        {
            container = new WindsorContainer();

            installer = new AppInstaller();
            container.Install(installer);
        }

        public class WhenInstalled : AppInstallerTests
        {
            [Test]
            public void ItShouldHaveAValidConfiguration()
            {
                container.AssertIsValid();
            }
        }
    }
}