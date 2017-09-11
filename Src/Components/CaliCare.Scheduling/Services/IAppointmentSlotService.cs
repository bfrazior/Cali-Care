using System;

namespace CaliCare.Scheduling.Services
{
   public interface IAppointmentSlotService
   {
      void GetNextOpenAppointmentSlot(DateTime fromDateTime, Guid staffId);
   }
}
