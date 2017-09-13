using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.Repositories;
using CaliCare.Schedule.Domain;

namespace CaliCare.Schedule.Application.Commands.Handlers
{
   public class CreateAppointmentCommandHandler : ICommandHandler<CreateAppointmentCommand>
   {
      private readonly IAppointmentRepository _appointmentRepository;

      public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
      {
         _appointmentRepository = appointmentRepository;
      }

      public void Handle(CreateAppointmentCommand message)
      {
         var appointment = Appointment.Create(
            message.ClinicalActivityId, 
            message.PatientId, 
            ScheduleConverter.ConvertToDomain(message.Staff), 
            ScheduleConverter.ConvertToDomain(message.Slot));

         _appointmentRepository.Store(appointment);
      }
   }
}
