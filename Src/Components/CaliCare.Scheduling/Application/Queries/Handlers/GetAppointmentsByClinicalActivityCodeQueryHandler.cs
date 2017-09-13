using System;
using System.Collections.Generic;
using System.Linq;

using MediatR;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Infrastructure.Extensions;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Schedule.Ports.Repositories;

namespace CaliCare.Schedule.Application.Queries.Handlers
{
   public class GetAppointmentsByClinicalActivityCodeQueryHandler : IQueryHandler<GetAppointmentsByClinicalActivityCodeQuery, IReadOnlyList<AppointmentDto>>
   {
      private readonly IAppointmentRepository _appointmentRepository;
      private readonly IMediator _mediator;

      public GetAppointmentsByClinicalActivityCodeQueryHandler(
         IAppointmentRepository appointmentRepository,
         IMediator mediator)
      {
         _appointmentRepository = appointmentRepository;
         _mediator = mediator;
      }

      public IReadOnlyList<AppointmentDto> Handle(GetAppointmentsByClinicalActivityCodeQuery message)
      {
         if (string.IsNullOrEmpty(message.ClinicalActivityCode))
            throw new ArgumentException($"{nameof(message.ClinicalActivityCode)} cannot be empty or undefined.");

         var clinicalActivity = _mediator.SendSync(new GetClinicalActivityByCodeQuery() { Code = message.ClinicalActivityCode });
         if (clinicalActivity == null)
            throw new ArgumentException($"{nameof(GetClinicalActivityByCodeQuery)} did not return a result.");

         return _appointmentRepository.FindAllByClinicalActivityId(clinicalActivity.Id)
            .Select(x => ScheduleConverter.ConvertToDto(x))
            .ToList();
      }
   }
}
