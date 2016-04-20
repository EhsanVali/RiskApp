using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RiskApplication.CrossCuttingConcerns.Logging;

namespace RiskApplication.CrossCuttingConcerns.DependencyInjection.Installer
{
    public class CrossCuttingConcernsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ExceptionLogger>());
        }
    }
}