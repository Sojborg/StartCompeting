﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.Interfaces;
using Core.Models;
using Infrastruture;
using Infrastruture.Repositories;
using Infrastruture.Services;
using Ninject;
using Ninject.Web.Common;
using StartCompeting.Frontend.Web.App_Start;

namespace StartCompeting.Frontend.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
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

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //RegisterRoutes(RouteTable.Routes);
            //AuthConfig.RegisterAuth();
            CreateKernel();
        }

        protected override Ninject.IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<StartCompetingContext>().ToSelf().InSingletonScope();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IWorkoutService>().To<WorkoutService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRepository<Race>>().To<Repository<Race>>();
            kernel.Bind<IRepository<RaceType>>().To<Repository<RaceType>>();
            kernel.Bind<IRepository<Workout>>().To<Repository<Workout>>();
            kernel.Bind<IRaceTypeService>().To<RaceTypeService>();
            kernel.Bind<IRaceService>().To<RaceService>();
            kernel.Bind<ILeagueTypeService>().To<LeagueTypeService>();
            kernel.Bind<ILeagueService>().To<LeagueService>();
            return kernel;
        }
    }
}