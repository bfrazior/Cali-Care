using System;
using System.Linq;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Schedule.Domain
{
   public class ScheduleSlot : IAggregateRoot
   {
      public Guid Id { get; }
      public DateTime Date { get; }
      public int SlotNumber { get; }

      public Guid[] Appointments { get; private set; }

      public ScheduleSlot(Guid id, DateTime date, int slotNumber, Guid[] appointments)
      {
         Id = id;
         Date = date.Date;
         SlotNumber = slotNumber;
         Appointments = appointments;
      }

      public static ScheduleSlot Create(DateTime date, int slotNumber, Guid[] appointments)
         => new ScheduleSlot(Guid.NewGuid(), date, slotNumber, appointments);

      public void AddAppointment(Guid appointmentId)
      {
         if (Appointments == null)
         {
            Appointments = new Guid[] { appointmentId };
            return;
         }

         if (Appointments.Where(x => x == appointmentId).SingleOrDefault() == null)
         {
            Appointments = Appointments.Concat(new Guid[] { appointmentId }).ToArray();
            return;
         }
      }
   }
}
