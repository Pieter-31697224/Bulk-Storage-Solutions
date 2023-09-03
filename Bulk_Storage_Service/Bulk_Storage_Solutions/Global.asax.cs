using Autofac;
using Bulk_Storage_Solutions.DAL.Features.ClientStorageAgreement;
using Bulk_Storage_Solutions.DAL.Features.Contracts;
using Bulk_Storage_Solutions.DAL.Features.Cargo;
using Bulk_Storage_Solutions.DAL.Features.Storage;
using Bulk_Storage_Solutions.DAL.Features.StorageType;
using Bulk_Storage_Solutions.DAL.SqlDbConnection;
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
            builder.RegisterType<CargoFunctions>().As<ICargo>().SingleInstance();
            builder.RegisterType<StorageTypeFunctions>().As<IStorageType>().SingleInstance();
            builder.RegisterType<StorageFunctions>().As<IStorage>().SingleInstance();
            builder.RegisterType<ClientStorageAgreementFunctions>().As<IClientStorageAgreement>().SingleInstance();


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