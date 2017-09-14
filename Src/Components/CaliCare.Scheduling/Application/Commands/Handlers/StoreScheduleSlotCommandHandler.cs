using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.Repositories;

namespace CaliCare.Schedule.Application.Commands.Handlers
{
   public class StoreScheduleSlotCommandHandler : ICommandHandler<StoreScheduleSlotCommand>
   {
      private readonly IScheduleSlotRepository _slotRepository;

      public StoreScheduleSlotCommandHandler(IScheduleSlotRepository slotRepository)
      {
         _slotRepository = slotRepository;
      }

      public void Handle(StoreScheduleSlotCommand message)
      {
         if (message.Slot == null)
            throw new ArgumentNullException($"{nameof(message.Slot)} cannot be undefined.");

         _slotRepository.Store(ScheduleConverter.ConvertToDomain(message.Slot));
      }
   }
}
