using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Schedule.Ports.Repositories;

namespace CaliCare.Schedule.Application.Queries.Handlers
{
   public class GetAppointmentQueryHandler : IQueryHandler<GetAppointmentQuery, AppointmentDto>
   {
      private readonly IAppointmentRepository _appointmentRepository;

      public GetAppointmentQueryHandler(IAppointmentRepository appointmentRepository)
      {
         _appointmentRepository = appointmentRepository;
      }

      public AppointmentDto Handle(GetAppointmentQuery message)
      {
         if (message.Id == Guid.Empty)
            throw new ArgumentException($"{nameof(message.Id)} cannot be empty.");

         return ScheduleConverter.ConvertToDto(_appointmentRepository.Find(message.Id));
      }
   }
}
