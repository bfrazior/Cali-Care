using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.Patients.Application.Queries
{
   public class GetPatientsQuery : IQuery<IReadOnlyList<PatientDto>>
   {
   }
}
