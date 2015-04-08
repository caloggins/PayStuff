namespace PayStuffWeb.Tests
{
    using System;
    using System.Linq;
    using System.Text;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Handlers;
    using Castle.Windsor;
    using Castle.Windsor.Diagnostics;

    public static class ContainerAssertions
    {
        public static void AssertIsValid(this IWindsorContainer container)
        {
            var host = (IDiagnosticsHost)container.Kernel.GetSubSystem(SubSystemConstants.DiagnosticsKey);
            var diagnostics = host.GetDiagnostic<IPotentiallyMisconfiguredComponentsDiagnostic>();

            var handlers = diagnostics.Inspect();

            if (handlers.Any())
            {
                var message = new StringBuilder();
                var inspector = new DependencyInspector(message);

                // ReSharper disable once PossibleInvalidCastExceptionInForeachLoop
                foreach (IExposeDependencyInfo handler in handlers)
                {
                    handler.ObtainDependencyDetails(inspector);
                }

                throw new MisconfiguredComponentException(message.ToString());
            }
        }
    }

    public class MisconfiguredComponentException : Exception
    {
        public MisconfiguredComponentException(string message)
            : base(message)
        { }
    }
}