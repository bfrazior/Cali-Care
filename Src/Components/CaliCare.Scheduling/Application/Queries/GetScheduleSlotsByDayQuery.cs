using System;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Queries
{
   public class GetScheduleSlotsByDayQuery : IQuery<IReadOnlyList<ScheduleSlotDto>>
   {
      public DateTime Date { get; set; }
   }
}
