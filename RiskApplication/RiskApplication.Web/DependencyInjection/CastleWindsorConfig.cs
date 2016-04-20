using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.Mvc;
using RiskApplication.CrossCuttingConcerns.DependencyInjection;
using RiskApplication.Web.DependencyInjection;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(CastleWindsorConfig), "Start")]
[assembly: ApplicationShutdownMethod(typeof(CastleWindsorConfig), "Stop")]

namespace RiskApplication.Web.DependencyInjection
{
    public static class CastleWindsorConfig
    {
        private static IWindsorContainer _container;

        public static void Start()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            new CompositionRoot().ComposeApplication(_container);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            _container?.Dispose();
        }
    }
}