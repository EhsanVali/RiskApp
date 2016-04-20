using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RiskApplication.Domain.BusinessRules;

namespace RiskApplication.CrossCuttingConcerns.DependencyInjection.Installer
{
    public class DomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHighPriceBusinessRule>()
                                        .ImplementedBy<HighPriceBusinessRule>());

            container.Register(Component.For<IHighlyUnusualStakeBusinessRule>()
                                        .ImplementedBy<HighlyUnusualStakeBusinessRule>());

            container.Register(Component.For<IUnusualStakeBusinessRule>()
                                        .ImplementedBy<UnusualStakeBusinessRule>());

            container.Register(Component.For<IUnusualWinRateBusinessRule>()
                                        .ImplementedBy<UnusualWinRateBusinessRule>());
        }
    }
}