using System;

namespace CaliCare.Schedule.Ports.DataTransferObjects
{
   public class ScheduleSlotDto
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public int SlotNumber { get; set; }
      public Guid[] Appointments { get; set; }
   }
}
