﻿using System;
using System.Collections.Generic;
using System.Web.Http;

using MediatR;

using CaliCare.Infrastructure.Extensions;
using CaliCare.Schedule.Application.Commands;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Schedule.Application.Queries;

namespace CaliCare.WebApi.Adapters.Controllers
{
   [RoutePrefix("api/schedule")]
   public class ScheduleController : ApiController
    {
      private readonly IMediator _mediator;

      public ScheduleController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [Route("appointments/create")]
      public void CreateAppointment([FromBody]CreateAppointmentDto createAppointmentDto)
      {
         _mediator.SendSync(new CreateAppointmentCommand()
         {
            ClinicalActivityId = createAppointmentDto.ClinicalActivityId,
            Date = createAppointmentDto.Date,
            NumberOfSlots = createAppointmentDto.NumberOfSlots,
            PatientConditionId = createAppointmentDto.PatientConditionId,
            PatientId = createAppointmentDto.PatientId,
            RoomChoices = createAppointmentDto.RoomChoices,
            StaffChoices = createAppointmentDto.StaffChoices,
            StartSlot = createAppointmentDto.StartSlot
         });
      }

      [Route("appointments/consult/create")]
      public void CreateConsultAppointment([FromBody]CreateAppointmentDto createAppointmentDto)
      {
         _mediator.SendSync(new ScheduleNewPatientConsultationCommand()
         {
            ClinicalActivityId = createAppointmentDto.ClinicalActivityId,
            Date = createAppointmentDto.Date,
            DepartmentId = createAppointmentDto.DepartmentId,
            NumberOfSlots = createAppointmentDto.NumberOfSlots,
            PatientConditionId = createAppointmentDto.PatientConditionId,
            PatientId = createAppointmentDto.PatientId,
            StartSlot = createAppointmentDto.StartSlot
         });
      }

      [Route("appointments/{clinicalActivityCode}")]
      public IEnumerable<AppointmentDto> GetAppointmentsByClinicalActivityCode(string clinicalActivityCode)
      {
         return _mediator.SendSync(new GetAppointmentsByClinicalActivityCodeQuery() { ClinicalActivityCode = clinicalActivityCode });
      }

      [Route("appointments/slots/{appointmentId:Guid}")]
      public IEnumerable<ScheduleSlotDto> GetAppointmentSlots(Guid appointmentId, string date)
      {
         return _mediator.SendSync(new GetScheduleSlotsByAppointmentQuery() { AppointmentDate = DateTime.Parse(date), AppointmentId = appointmentId });
      }

      [Route("activities/{code}")]
      public ClinicalActivityDto GetClinicalActivityByCode(string code)
      {
         return _mediator.SendSync(new GetClinicalActivityByCodeQuery() { Code = code });
      }
   }
}
