﻿using Autofac;
using Bulk_Storage_Solutions.DAL.Features.Contracts;
using Bulk_Storage_Solutions.DAL.Features.StorageType;
using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.DAL.Features.IClients;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bulk_Storage_Solutions
{
    public class Global : HttpApplication
    {
        private static IContainer _container;
        void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OpenSqlDbConnection>().As<ISqlDbConnection>().SingleInstance();
            builder.RegisterType<ContractFunctions>().As<IContracts>().SingleInstance();
            builder.RegisterType<StorageTypeFunctions>().As<IStorageType>().SingleInstance();
            builder.RegisterType<ClientFunctionality>().As<IClient>().SingleInstance();


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