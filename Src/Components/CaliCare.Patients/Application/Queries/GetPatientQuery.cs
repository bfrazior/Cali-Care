using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.Patients.Application.Queries
{
   public class GetPatientQuery : IQuery<PatientDto>
   {
      public Guid Id { get; set; }
   }
}
