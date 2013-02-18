using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.ActiveRecord;
using OSI.Models;
using Castle.ActiveRecord.Framework.Config;
using Ninject;
using Ninject.Modules;
using OSI.Repositories;
using System.Web.Security;

namespace OSI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        internal class MyNinjectModules : NinjectModule
        {
            public override void Load()
            {
                Bind<IRepository<Users>>()
                    .To<BaseRepository<Users>>();
            }
        }

        private IKernel _kernel = new StandardKernel(new MyNinjectModules());

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ActiveRecordStarter.Initialize(ActiveRecordSectionHandler.Instance,
                typeof(Users)
            );

            ActiveRecordStarter.CreateSchema();

            _kernel.Inject(Membership.Provider);
        }
    }
}