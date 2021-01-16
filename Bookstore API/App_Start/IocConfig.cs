using Autofac;
using Autofac.Integration.WebApi;
using Bookstore_API.Repository;
using System.Reflection;
using System.Web.Http;

namespace Bookstore_API.App_Start
{
    public class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<LibraryRepository>().AsImplementedInterfaces();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}