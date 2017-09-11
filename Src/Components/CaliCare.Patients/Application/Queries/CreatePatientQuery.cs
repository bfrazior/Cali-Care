using CaliCare.Infrastructure.Interfaces;
using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.Patients.Application.Queries
{
   public class CreatePatientQuery : IQuery<PatientDto>
   {
      public PatientNameDto PatientName { get; set; }
   }
}
