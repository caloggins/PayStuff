namespace PayStuffWeb.Code
{
    using System.Data;
    using AutoMapper;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class AppInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbConnection>().UsingFactoryMethod(DatabaseConnection.Create).LifestyleTransient(),
                Component.For<IMappingEngine>().UsingFactoryMethod(() => Mapper.Engine).LifestyleSingleton()
                );
        }
    }
}