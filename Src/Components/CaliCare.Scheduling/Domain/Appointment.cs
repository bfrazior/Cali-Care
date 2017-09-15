using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Common;

namespace CaliCare.Schedule.Domain
{
   public class Appointment : IAggregateRoot
   {
      public Guid Id { get; }
      public Guid ClinicalActivityId { get; }
      public DateTime Date { get; }
      public Guid? PatientConditionId { get; }
      public Guid PatientId { get; }
      public Guid RoomId { get; }

      public AppointmentStaff Staff { get; private set; }
      public AppointmentStatus Status { get; private set; }

      public Appointment(
         Guid id,
         DateTime date,
         Guid clinicalActivityId,
         Guid patientId,
         Guid? patientConditionId,
         Guid roomId,
         AppointmentStaff staff,
         AppointmentStatus status)
      {
         Id = id;
         Date = date.Date;
         ClinicalActivityId = clinicalActivityId;
         PatientId = patientId;
         PatientConditionId = patientConditionId;
         RoomId = roomId;
         Staff = staff;
         Status = status;
      }

      public static Appointment Create(
         DateTime date,
         Guid clinicalActivityId, 
         Guid patientId,
         Guid? patientConditionId,
         Guid roomId,
         AppointmentStaff staff)
      {
         if (date == DateTime.MinValue)
            throw new ArgumentException($"{nameof(date)} cannot be set to is default value.");

         if (clinicalActivityId == Guid.Empty)
            throw new ArgumentException($"{nameof(clinicalActivityId)} cannot be empty.");

         if (patientId == Guid.Empty)
            throw new ArgumentException($"{nameof(patientId)} cannot be empty.");

         if (roomId == Guid.Empty)
            throw new ArgumentException($"{nameof(roomId)} cannot be empty.");

         if (staff == null)
            throw new ArgumentException($"{nameof(staff)} cannot be undefined.");

         return new Appointment(Guid.NewGuid(), date.Date, clinicalActivityId, patientId, patientConditionId, roomId, staff, AppointmentStatus.Pending);
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
