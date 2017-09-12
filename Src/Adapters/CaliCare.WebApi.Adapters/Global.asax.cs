using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using MediatR;
using SimpleInjector.Integration.WebApi;

using CaliCare.WebApi.Adapters.App_Start;
using CaliCare.Infrastructure.Extensions;
using CaliCare.Resources.Application.Commands;
using CaliCare.Conditions.Application.Commands;

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
         var mediator = container.GetInstance<IMediator>();
         mediator.SendSync(new SeedDepartmentsCommand());
         mediator.SendSync(new SeedRoomsCommand());
         mediator.SendSync(new SeedMachinesCommand());
         mediator.SendSync(new SeedPhysiciansCommand());

         mediator.SendSync(new SeedTopographiesCommand());
      }
   }
}