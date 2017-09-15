using System;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Queries
{
   public class GetScheduleSlotsByAppointmentQuery : IQuery<IReadOnlyList<ScheduleSlotDto>>
   {
      public Guid AppointmentId { get; set; }
      public DateTime AppointmentDate { get; set; }
   }
}
