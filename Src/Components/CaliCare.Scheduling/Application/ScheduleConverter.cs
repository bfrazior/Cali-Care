using CaliCare.Schedule.Domain;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application
{
   internal static class ScheduleConverter
   {
      public static AppointmentStaff ConvertToDomain(AppointmentStaffDto staffDto)
         => staffDto == null ? null : new AppointmentStaff(
            staffDto.AppointmentStaffId, 
            staffDto.AppointmentStaffType);

      public static ScheduleSlot ConvertToDomain(ScheduleSlotDto slotDto)
         => slotDto == null ? null : new ScheduleSlot(
            slotDto.Id,
            slotDto.Date, 
            slotDto.SlotNumber, 
            slotDto.Appointments);

      public static AppointmentDto ConvertToDto(Appointment appointment)
         => appointment == null ? null : new AppointmentDto()
         {
            ClinicalActivityId = appointment.ClinicalActivityId,
            Id = appointment.Id,
            PatientId = appointment.PatientId,
            PatientConditionId = appointment.PatientConditionId,
            RoomId = appointment.RoomId,
            Staff = ConvertToDto(appointment.Staff),
            Status = appointment.Status
         };

      public static AppointmentStaffDto ConvertToDto(AppointmentStaff staff)
         => staff == null ? null : new AppointmentStaffDto()
         {
            AppointmentStaffId = staff.AppointmentStaffId,
            AppointmentStaffType = staff.AppointmentStaffType
         };

      public static ClinicalActivityDto ConvertToDto(ClinicalActivity activity)
         => activity == null ? null : new ClinicalActivityDto()
         {
            Code = activity.Code,
            Id = activity.Id,
            Name = activity.Name
         };

      public static ScheduleSlotDto ConvertToDto(ScheduleSlot slot)
         => slot == null ? null : new ScheduleSlotDto()
         {
            Id = slot.Id,
            Date = slot.Date,
            Appointments = slot.Appointments,
            SlotNumber = slot.SlotNumber
         };

   }
}
