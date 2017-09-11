using CaliCare.Infrastructure.Interfaces;
using CaliCare.Registration.Ports.Services;

namespace CaliCare.Registration.Application.Commands.Handlers
{
   public class AdmitPatientCommandHandler : ICommandHandler<AdmitPatientCommand>
   {
      private readonly IAdmitSchedulingService _admitSchedultingService;

      public AdmitPatientCommandHandler(IAdmitSchedulingService admitSchedulingService)
      {
         _admitSchedultingService = admitSchedulingService;
      }

      public void Handle(AdmitPatientCommand message)
      {
         _admitSchedultingService.ScheduleConsultation();
      }
   }
}
