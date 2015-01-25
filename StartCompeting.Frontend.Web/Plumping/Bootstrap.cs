using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using Castle.Windsor;
using StartCompeting.Frontend.Web.Installers;

namespace StartCompeting.Frontend.Web.Plumping
{
    public class Bootstrap
    {
        private static readonly WindsorContainer WindsorContainer = new WindsorContainer();

        public Bootstrap()
        {
        }

        public void InstallDependencies()
        {
            WindsorContainer.Install(new DatabaseInstall(),
                new ServicesInstaller(),
                new WebApiControllerInstaller());

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(WindsorContainer));   
        }

        public void HandleExceptions()
        {
            GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger), new NlogExceptionLogger());
        }
    }
}