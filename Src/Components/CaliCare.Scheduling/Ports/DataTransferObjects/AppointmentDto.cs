using System;

using CaliCare.Schedule.Common;

namespace CaliCare.Schedule.Ports.DataTransferObjects
{
   public class AppointmentDto
   {
      public Guid Id { get; set; }
      public Guid RoomId { get; set; }
      public ScheduleSlotDto[] Slots { get; set; }
      public AppointmentStaffDto Staff { get; set; }
      public AppointmentStatus Status { get; set; }
      public Guid ClinicalActivityId { get; set; }
      public Guid? PatientConditionId { get; set; }
      public Guid PatientId { get; set; }
   }

   public class AppointmentStaffDto
   {
      public Guid AppointmentStaffId { get; set; }
      public string AppointmentStaffType { get; set; }
   }
}
