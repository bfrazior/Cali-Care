using System;

namespace CaliCare.Schedule.Ports.DataTransferObjects
{
   public class CreateAppointmentDto
   {
      public Guid ClinicalActivityId { get; set; }
      public DateTime Date { get; set; }
      public Guid PatientConditionId { get; set; }
      public Guid PatientId { get; set; }
      public Guid[] RoomChoices { get; set; }
      public int NumberOfSlots { get; set; }
      public int StartSlot { get; set; }
      public AppointmentStaffDto[] StaffChoices { get; set; }
   }
}
