using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Core.Interfaces;
using Core.Models;
using Infrastruture;
using Infrastruture.Repositories;
using Infrastruture.Services;
using StartCompeting.Frontend.Web.App_Start;
using StartCompeting.Frontend.Web.Plumping;

namespace StartCompeting.Frontend.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        "Default", // Route name
        //        "{controller}/{action}/{id}", // URL with parameters
        //        new
        //        {
        //            controller = "Home",
        //            action = "Index",
        //            id = UrlParameter.Optional
        //        });
        //}

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            
            var bootstrap = new Bootstrap();
            bootstrap.InstallDependencies();
            bootstrap.HandleExceptions();
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/log4net.config")));
        }
    }
}