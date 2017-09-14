using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Commands
{
   public class StoreScheduleSlotCommand : ICommand
   {
      public ScheduleSlotDto Slot { get; set; }
   }
}
