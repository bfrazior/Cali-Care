using System;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Scheduling.Application.Commands
{
   public class ScheduleAppointmentCommand : ICommand
   {
      public string Context { get; set; }
      public Guid ClinicalActivityId { get; set; }
      public DateTime StartAt { get; set; }
      public int LengthInMins { get; set; }
   }
}
