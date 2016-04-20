using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using RiskApplication.Web.Models.Mapper;

namespace RiskApplication.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //TODO: Move to DI
            Mapper.Initialize(a => a.AddProfile<RiskProfile>());
            Mapper.Initialize(a => a.AddProfile<CustomerProfile>());
            Mapper.Initialize(a => a.AddProfile<SettledBetProfile>());
            Mapper.AssertConfigurationIsValid();
        }
    }
}