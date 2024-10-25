using Autofac.Integration.Mvc;
using Autofac;
using DependencyInjection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DependencyInjection.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register all MVC controllers in the assembly
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register service types
            builder.RegisterType<ProductService>().As<IProductService>();

            var container = builder.Build();

            // Set Autofac as the Dependency Resolver for MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}