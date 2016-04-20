using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RiskApplication.Domain;
using RiskApplication.Persistence;

namespace RiskApplication.CrossCuttingConcerns.DependencyInjection.Installer
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRiskRepository>()
                                        .ImplementedBy<RiskRepository>()
                                        .LifestyleSingleton());
        }
    }
}