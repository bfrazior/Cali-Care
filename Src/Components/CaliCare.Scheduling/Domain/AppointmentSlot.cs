using System;

namespace CaliCare.Schedule.Domain
{
   public class AppointmentSlot
   {
      public int LengthInMins { get; }
      public Guid RoomId { get; }
      public DateTime StartAt { get; }

      public AppointmentSlot(Guid roomId, DateTime startAt, int lengthInMins)
      {
         RoomId = roomId;
         StartAt = startAt;
         LengthInMins = lengthInMins;
      }
   }
}
