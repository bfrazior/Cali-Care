using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Common;

namespace CaliCare.Schedule.Domain
{
   public class Appointment : IAggregateRoot
   {
      public Guid Id { get; }
      public Guid ClinicalActivityId { get; }
      public Guid PatientId { get; }

      public AppointmentSlot Slot { get; private set; }
      public AppointmentStaff Staff { get; private set; }
      public AppointmentStatus Status { get; private set; }

      public Appointment(
         Guid id,
         Guid clinicalActivityId,
         Guid patientId,
         AppointmentStaff staff,
         AppointmentSlot slot,
         AppointmentStatus status)
      {
         Id = id;
         ClinicalActivityId = clinicalActivityId;
         PatientId = patientId;
         Staff = staff;
         Slot = slot;
         Status = status;
      }

      public static Appointment Create(
         Guid clinicalActivityId, 
         Guid patientId, 
         AppointmentStaff staff,
         AppointmentSlot slot)
      {
         if (clinicalActivityId == Guid.Empty)
            throw new ArgumentException($"{nameof(clinicalActivityId)} cannot be empty.");

         if (patientId == Guid.Empty)
            throw new ArgumentException($"{nameof(patientId)} cannot be empty.");

         if (staff == null)
            throw new ArgumentException($"{nameof(staff)} cannot be undefined.");

         if (slot == null)
            throw new ArgumentException($"{nameof(slot)} cannot be undefined.");

         return new Appointment(Guid.NewGuid(), clinicalActivityId, patientId, staff, slot, AppointmentStatus.Pending);
      }

      public void SetSlot(AppointmentSlot slot)
      {
         if (slot == null)
            throw new ArgumentException($"{nameof(slot)} cannot be undefined.");

         Slot = slot;
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
