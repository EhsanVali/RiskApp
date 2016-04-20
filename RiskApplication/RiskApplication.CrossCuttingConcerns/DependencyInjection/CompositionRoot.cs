using Castle.Facilities.Logging;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace RiskApplication.CrossCuttingConcerns.DependencyInjection
{
    public class CompositionRoot
    {
        public virtual void ComposeApplication(IWindsorContainer container)
        {
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.NLog));
            container.Install(FromAssembly.This());
        }
    }
}