using System;
using System.Collections.Generic;
using System.Linq;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Schedule.Ports.Repositories;
using CaliCare.Schedule.Domain;

namespace CaliCare.Schedule.Application.Queries.Handlers
{
   public class GetScheduleSlotsByDayQueryHandler : IQueryHandler<GetScheduleSlotsByDayQuery, IReadOnlyList<ScheduleSlotDto>>
   {
      private readonly IScheduleSlotRepository _slotRepository;

      public GetScheduleSlotsByDayQueryHandler(IScheduleSlotRepository slotRepository)
      {
         _slotRepository = slotRepository;
      }

      public IReadOnlyList<ScheduleSlotDto> Handle(GetScheduleSlotsByDayQuery message)
      {
         if (message.Date == DateTime.MinValue)
            throw new ArgumentException($"{nameof(message.Date)} cannot be set to its min value.");

         var scheduleDaySlots = _slotRepository.FindAll(message.Date.Date);
         if (scheduleDaySlots.Count > 0)
            return scheduleDaySlots.Select(x => ScheduleConverter.ConvertToDto(x)).ToList();


         var defaultSlots = new List<ScheduleSlot>();
         for (var slotNumber = 0; slotNumber <= 31; slotNumber++)
            defaultSlots.Add(ScheduleSlot.Create(message.Date.Date, slotNumber, null));

         defaultSlots.ForEach(x => _slotRepository.Store(x));
         return defaultSlots.Select(x => ScheduleConverter.ConvertToDto(x)).ToList();
      }
   }
}
