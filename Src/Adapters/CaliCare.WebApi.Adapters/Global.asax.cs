using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using MediatR;
using SimpleInjector.Integration.WebApi;

using CaliCare.WebApi.Adapters.App_Start;

namespace CaliCare.WebApi.Adapters
{
   public class Global : HttpApplication
   {
      void Application_Start(object sender, EventArgs e)
      {
         // Configure Simple Injector
         var container = ContainerConfig.Register();
         GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

         // Code that runs on application startup
         AreaRegistration.RegisterAllAreas();
         GlobalConfiguration.Configure(WebApiConfig.Register);
         RouteConfig.RegisterRoutes(RouteTable.Routes);

         // Seed data
         DataConfig.Seed(container.GetInstance<IMediator>());
      }
   }
}