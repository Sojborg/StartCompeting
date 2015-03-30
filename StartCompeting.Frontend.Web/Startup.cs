using System.IO;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using Castle.Windsor;
using Microsoft.Owin;
using Owin;
using StartCompeting.Frontend.Web.App_Start;
using StartCompeting.Frontend.Web.Installers;
using StartCompeting.Frontend.Web.Plumping;

[assembly: OwinStartup(typeof(StartCompeting.Frontend.Web.Startup))]
namespace StartCompeting.Frontend.Web
{
    public class Startup
    {
        private static readonly WindsorContainer WindsorContainer = new WindsorContainer();

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WindsorContainer.Install(new DatabaseInstall(),
                new ServicesInstaller(),
                new WebApiControllerInstaller());

            config.Services.Add(typeof(IExceptionLogger), new Log4ExceptionLogger());
            config.DependencyResolver = new WindsorResolver(WindsorContainer.Kernel);

            var logPath = config.VirtualPathRoot;
            log4net.Config.XmlConfigurator.Configure(new FileInfo("/log4net.config"));
            
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}