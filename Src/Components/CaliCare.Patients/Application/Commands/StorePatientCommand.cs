using CaliCare.Infrastructure.Interfaces;
using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.Patients.Application.Commands
{
   public class StorePatientCommand : ICommand
   {
      public PatientDto Patient { get; set; }
   }
}
