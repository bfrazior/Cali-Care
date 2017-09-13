using System;

namespace CaliCare.Schedule.Domain
{
   public class AppointmentStaff
   {
      public Guid AppointmentStaffId { get; }
      public string AppointmentStaffType { get; }

      public AppointmentStaff(Guid appointmentStaffId, string appointmentStaffType)
      {
         AppointmentStaffId = appointmentStaffId;
         AppointmentStaffType = appointmentStaffType;
      }
   }
}
