using System;
using System.Collections.Generic;
using System.Linq;

using MediatR;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Extensions;

namespace CaliCare.Schedule.Application.Queries.Handlers
{
   public class GetScheduleSlotsByAppointmentQueryHandler : IQueryHandler<GetScheduleSlotsByAppointmentQuery, IReadOnlyList<ScheduleSlotDto>>
   {
      private readonly IMediator _mediator;

      public GetScheduleSlotsByAppointmentQueryHandler(IMediator mediator)
      {
         _mediator = mediator;
      }

      public IReadOnlyList<ScheduleSlotDto> Handle(GetScheduleSlotsByAppointmentQuery message)
      {
         if (message.AppointmentId == Guid.Empty)
            throw new ArgumentException($"{nameof(message.AppointmentId)} cannot be empty.");

         if (message.AppointmentDate == DateTime.MinValue)
            throw new ArgumentException($"{nameof(message.AppointmentDate)} cannot be set to its default value.");

         var apptSlots = new List<ScheduleSlotDto>();

         var scheduleDaySlots = _mediator.SendSync(new GetScheduleSlotsByDayQuery() { Date = message.AppointmentDate.Date });
         foreach(var slot in scheduleDaySlots)
         {
            if (slot.Appointments.ToList().Contains(message.AppointmentId))
               apptSlots.Add(slot);
         }

         return apptSlots;
      }
   }
}
