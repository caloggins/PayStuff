namespace PayStuffLib
{
    using System.Collections.Concurrent;
    using AutoMapper;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Core;
    using Employees;

    public class PayStuffLibInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IQueryFactory>().AsFactory(),
                Classes.FromThisAssembly().BasedOn<IQuery>().WithServiceSelf().LifestylePerWebRequest(),
                Component.For<BlockingCollection<Employee>>().UsingFactoryMethod(() => new BlockingCollection<Employee>()).LifestyleSingleton(),
                Classes.FromThisAssembly().BasedOn<Command>().LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn<Profile>().WithServiceBase()
                );
        }
    }
}