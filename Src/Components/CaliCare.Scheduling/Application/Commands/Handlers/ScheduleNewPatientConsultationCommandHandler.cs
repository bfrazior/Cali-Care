using MediatR;

using CaliCare.Infrastructure.Extensions;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Application.Queries;
using CaliCare.Schedule.Ports.Services;

namespace CaliCare.Schedule.Application.Commands.Handlers
{
   public class ScheduleNewPatientConsultationCommandHandler : ICommandHandler<ScheduleNewPatientConsultationCommand>
   {
      private readonly IConsultationService _consultService;
      private readonly IMediator _mediator;

      public ScheduleNewPatientConsultationCommandHandler(
         IConsultationService consultService,
         IMediator mediator)
      {
         _consultService = consultService;
         _mediator = mediator;
      }

      public void Handle(ScheduleNewPatientConsultationCommand message)
      {
         var consultResources = _consultService.GetConsultationResources(message.DepartmentId, message.PatientConditionId);
         var clinicalActivity = _mediator.SendSync(new GetClinicalActivityByCodeQuery() { Code = "54321" });

         var createAppointmentCommand = new CreateAppointmentCommand()
         {
            ClinicalActivityId = clinicalActivity.Id,
            Date = message.Date.Date,
            NumberOfSlots = message.NumberOfSlots,
            PatientConditionId = message.PatientConditionId,
            PatientId = message.PatientId,
            RoomChoices = consultResources.Item2,
            StaffChoices = consultResources.Item1,
            StartSlot = message.StartSlot
         };
         _mediator.SendSync(createAppointmentCommand);
      }
   }
}
