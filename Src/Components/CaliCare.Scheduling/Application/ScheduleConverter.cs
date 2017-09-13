using CaliCare.Schedule.Domain;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application
{
   internal static class ScheduleConverter
   {
      public static AppointmentSlot ConvertToDomain(AppointmentSlotDto slotDto)
         => slotDto == null ? null : new AppointmentSlot(
            slotDto.RoomId,
            slotDto.StartAt,
            slotDto.LengthInMins);

      public static AppointmentStaff ConvertToDomain(AppointmentStaffDto staffDto)
         => staffDto == null ? null : new AppointmentStaff(
            staffDto.AppointmentStaffId, 
            staffDto.AppointmentStaffType);

      public static AppointmentDto ConvertToDto(Appointment appointment)
         => appointment == null ? null : new AppointmentDto()
         {
            ClinicalActivityId = appointment.ClinicalActivityId,
            Id = appointment.Id,
            PatientId = appointment.PatientId,
            Slot = ConvertToDto(appointment.Slot),
            Staff = ConvertToDto(appointment.Staff),
            Status = appointment.Status
         };

      public static AppointmentSlotDto ConvertToDto(AppointmentSlot slot)
         => slot == null ? null : new AppointmentSlotDto()
         {
            LengthInMins = slot.LengthInMins,
            RoomId = slot.RoomId,
            StartAt = slot.StartAt
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
   }
}
