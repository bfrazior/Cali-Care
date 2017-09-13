using MediatR;

using CaliCare.Infrastructure.Extensions;
using CaliCare.Resources.Application.Commands;
using CaliCare.Conditions.Application.Commands;
using CaliCare.Schedule.Application.Commands;

namespace CaliCare.WebApi.Adapters.App_Start
{
   public static class DataConfig
   {
      public static void Seed(IMediator mediator)
      {
         mediator.SendSync(new SeedDepartmentsCommand());
         mediator.SendSync(new SeedRoomsCommand());
         mediator.SendSync(new SeedMachinesCommand());
         mediator.SendSync(new SeedPhysiciansCommand());

         mediator.SendSync(new SeedTopographiesCommand());

         mediator.SendSync(new SeedClinicalActivitiesCommand());
      }
   }
}