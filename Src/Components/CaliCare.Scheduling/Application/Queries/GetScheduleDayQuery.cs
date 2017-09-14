using System;


using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Queries
{
   public class GetScheduleDayQuery : IQuery<ScheduleDayDto>
   {
      public DateTime Date { get; set; }
   }
}
