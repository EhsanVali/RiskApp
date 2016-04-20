using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RiskApplication.Persistence.CsvFileProvider;
using RiskApplication.Web.CsvPath;

namespace RiskApplication.Web.DependencyInjection
{
    public class WebInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn<IController>()
                                      .LifestyleTransient());

            container.Register(Component.For<IFilePathsProvider>()
                                        .ImplementedBy<FilePathsProvider>()
                                        .LifestyleSingleton());
        }
    }
}