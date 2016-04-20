using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace RiskApplication.Web.DependencyInjection
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterProfilesAndResolvers(container);
            RegisterMapperEngine(container);

            Mapper.AssertConfigurationIsValid();
        }

        private void RegisterMapperEngine(IWindsorContainer container)
        {
            container.Register(Component.For<IMapper>()
                                        .UsingFactoryMethod(ctx => ctx.Resolve<MapperConfiguration>()
                                                                      .CreateMapper(ctx.Resolve)));
        }

        private void RegisterProfilesAndResolvers(IWindsorContainer container)
        {
            // register value resolvers
            container.Register(Classes.FromThisAssembly().BasedOn<IValueResolver>());

            // register profiles
            container.Register(Classes.FromThisAssembly().
                                       BasedOn<Profile>().
                                       WithServiceBase());

            var profiles = container.ResolveAll<Profile>();

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            container.Register(Component.For<MapperConfiguration>()
                                        .UsingFactoryMethod(() => config));
        }
    }
}