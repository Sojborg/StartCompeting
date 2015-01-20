using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastruture;

namespace StartCompeting.Frontend.Web.Installers
{
    public class DatabaseInstall : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<StartCompetingContext>().LifestyleScoped());
        }
    }
}