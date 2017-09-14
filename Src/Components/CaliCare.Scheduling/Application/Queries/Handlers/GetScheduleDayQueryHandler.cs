using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Schedule.Ports.Repositories;
using CaliCare.Schedule.Domain;

namespace CaliCare.Schedule.Application.Queries.Handlers
{
   public class GetScheduleDayQueryHandler : IQueryHandler<GetScheduleDayQuery, ScheduleDayDto>
   {
      private readonly IScheduleRepository _scheduleRepository;

      public GetScheduleDayQueryHandler(IScheduleRepository scheduleRepository)
      {
         _scheduleRepository = scheduleRepository;
      }

      public ScheduleDayDto Handle(GetScheduleDayQuery message)
      {
         if (message.Date == DateTime.MinValue)
            throw new ArgumentException($"{nameof(message.Date)} cannot be set to its min value.");

         var scheduleDay = _scheduleRepository.Find(message.Date);

         if (scheduleDay == null)
         {
            scheduleDay = ScheduleDay.Create(message.Date.Date);
            _scheduleRepository.Store(scheduleDay);
         }

         return ScheduleConverter.ConvertToDto(scheduleDay);
      }
   }
}
