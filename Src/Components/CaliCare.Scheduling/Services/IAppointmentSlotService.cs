using System;

using CaliCare.Schedule.Domain;

namespace CaliCare.Schedule.Services
{
   public interface IAppointmentSlotService
   {
      Tuple<ScheduleSlot[], Guid, AppointmentStaff> GetNextAvailableAppointmentSlots(
         DateTime searchStartDate, 
         int searchStartSlot, 
         AppointmentStaff[] staffSearch, 
         Guid[] roomSearch, 
         int slotsToFill);
   }
}
