using System;

namespace CaliCare.Schedule.Services
{
   public interface IAppointmentSlotService
   {
      void GetNextOpenAppointmentSlot(DateTime fromDateTime, Guid staffId);
   }
}
