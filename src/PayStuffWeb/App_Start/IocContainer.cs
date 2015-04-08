namespace PayStuffWeb
{
    using System.Web.Http;
    using AutoMapper;
    using Castle.Facilities.TypedFactory;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Microsoft.Ajax.Utilities;
    using WindsorSupport;

    public static class IocContainer
    {
        public static void RegisterObjects(HttpConfiguration configuration)
        {
            var container = new WindsorContainer();

            AddFacilities(container);

            LoadInstallers(container);

            LoadAutoMapperProfiles(container);

            configuration.DependencyResolver = new DependencyResolver(container.Kernel);
        }

        private static void LoadAutoMapperProfiles(IWindsorContainer container)
        {
            var profiles = container.ResolveAll<Profile>();
            Mapper.Initialize(configuration => profiles.ForEach(configuration.AddProfile));
        }

        private static void LoadInstallers(IWindsorContainer container)
        {
            container.Install(
                FromAssembly.This(),
                FromAssembly.Named("PayStuffLib")
                );
        }

        private static void AddFacilities(IWindsorContainer container)
        {
            container.AddFacility<TypedFactoryFacility>();
        }
    }
}