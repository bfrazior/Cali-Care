using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Queries
{
   public class GetAppointmentsByClinicalActivityCodeQuery : IQuery<IReadOnlyList<AppointmentDto>>
   {
      public string ClinicalActivityCode { get; set; }
   }
}
