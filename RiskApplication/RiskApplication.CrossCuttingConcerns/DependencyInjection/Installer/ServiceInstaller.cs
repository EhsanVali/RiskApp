using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RiskApplication.CrossCuttingConcerns.Logging;
using RiskApplication.Domain;
using RiskApplication.Services;

namespace RiskApplication.CrossCuttingConcerns.DependencyInjection.Installer
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRiskAnalysisService>()
                                        .ImplementedBy<RiskAnalysisService>()
                                        .LifestyleSingleton()
                                        .Interceptors<ExceptionLogger>());
        }
    }
}