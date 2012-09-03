[assembly: WebActivator.PreApplicationStartMethod(typeof(IoC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(IoC.App_Start.NinjectWebCommon), "Stop")]

namespace IoC.App_Start
{
    using System;
    using System.Configuration;
    using System.Web;
    using AutoMapper;
    using DataAccessLayer.Core;
    using DataAccessLayer.Interfaces;
    using Demo.DomainLogic;
    using Demo.Interfaces;
    using Demo.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDataAccess>().To<DataAccess>()
                  .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
            kernel.Bind<IMappingEngine>().ToMethod(ctx => Mapper.Engine);
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IShipperRepository>().To<ShipperRepository>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IOrderService>().To<OrderService>();
        }        
    }
}