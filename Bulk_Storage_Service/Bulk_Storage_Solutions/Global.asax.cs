using Autofac;
using Bulk_Storage_Solutions.DAL.Features.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Bulk_Storage_Solutions
{
    public class Global : HttpApplication
    {
        private static IContainer _container;
        void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ContractFunctions>().As<IContracts>().SingleInstance();


            _container = builder.Build();
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}