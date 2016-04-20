using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RiskApplication.Domain;
using RiskApplication.Domain.Models;
using RiskApplication.Persistence;
using RiskApplication.Persistence.CsvFileProvider;
using RiskApplication.Persistence.Factory;

namespace RiskApplication.CrossCuttingConcerns.DependencyInjection.Installer
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRiskRepository>()
                                        .ImplementedBy<RiskRepository>()
                                        .LifestyleSingleton());

            container.Register(Component.For(typeof(ICsvFileProvider<>))
                                        .ImplementedBy(typeof(CsvFileProvider<>))
                                        .LifestyleSingleton());

            container.Register(Component.For<IBetFactory<SettledBet>>()
                                        .ImplementedBy<SettledBetFactory>()
                                        .LifestyleSingleton());

            container.Register(Component.For<IBetFactory<UnsettledBet>>()
                                        .ImplementedBy<UnsettledBetFactory>()
                                        .LifestyleSingleton());
        }
    }
}