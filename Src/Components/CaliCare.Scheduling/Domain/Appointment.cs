using System;
using System.Linq;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Common;

namespace CaliCare.Schedule.Domain
{
   public class Appointment : IAggregateRoot
   {
      public Guid Id { get; }
      public Guid ClinicalActivityId { get; }
      public Guid? PatientConditionId { get; }
      public Guid PatientId { get; }
      public Guid RoomId { get; }

      public ScheduleSlot[] Slots { get; private set; }
      public AppointmentStaff Staff { get; private set; }
      public AppointmentStatus Status { get; private set; }

      public Appointment(
         Guid id,
         Guid clinicalActivityId,
         Guid patientId,
         Guid? patientConditionId,
         Guid roomId,
         AppointmentStaff staff,
         ScheduleSlot[] slots,
         AppointmentStatus status)
      {
         Id = id;
         ClinicalActivityId = clinicalActivityId;
         PatientId = patientId;
         PatientConditionId = patientConditionId;
         RoomId = roomId;
         Staff = staff;
         Slots = slots;
         Status = status;
      }

      public static Appointment Create(
         Guid clinicalActivityId, 
         Guid patientId,
         Guid? patientConditionId,
         Guid roomId,
         AppointmentStaff staff,
         ScheduleSlot[] slots)
      {
         if (clinicalActivityId == Guid.Empty)
            throw new ArgumentException($"{nameof(clinicalActivityId)} cannot be empty.");

         if (patientId == Guid.Empty)
            throw new ArgumentException($"{nameof(patientId)} cannot be empty.");

         if (roomId == Guid.Empty)
            throw new ArgumentException($"{nameof(roomId)} cannot be empty.");

         if (staff == null)
            throw new ArgumentException($"{nameof(staff)} cannot be undefined.");

         if (slots == null || slots.Count() == 0)
            throw new ArgumentException($"{nameof(slots)} cannot be empty or undefined.");

         var appointmentId = Guid.NewGuid();
         slots.ToList().ForEach(x => x.AddAppointment(appointmentId));

         return new Appointment(appointmentId, clinicalActivityId, patientId, patientConditionId, roomId, staff, slots, AppointmentStatus.Pending);
      }

      public void SetSlot(ScheduleSlot[] slots)
      {
         if (slots == null || slots.Count() == 0)
            throw new ArgumentException($"{nameof(slots)} cannot be empty or undefined.");

         Slots = slots;
      }

      public void SetStatus(AppointmentStatus status)
      {
         Status = status;
      }

      public void SetStaff(AppointmentStaff staff)
      {
         if (staff == null)
            throw new ArgumentException($"{nameof(staff)} cannot be undefined.");

         Staff = staff;
      }
   }
}
