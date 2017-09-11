using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Registration.Application.Commands
{
   public interface AdmitPatientCommand : ICommand
   {

      bool ScheduleConsult { get; set; }
   }
}
