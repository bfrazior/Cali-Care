using System;
using System.Linq;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.Repositories;
using CaliCare.Schedule.Domain;
using CaliCare.Schedule.Services;

namespace CaliCare.Schedule.Application.Commands.Handlers
{
   public class CreateAppointmentCommandHandler : ICommandHandler<CreateAppointmentCommand>
   {
      private readonly IAppointmentRepository _appointmentRepository;
      private readonly IAppointmentSlotService _slotService;

      public CreateAppointmentCommandHandler(
         IAppointmentSlotService slotService,
         IAppointmentRepository appointmentRepository)
      {
         _slotService = slotService;
         _appointmentRepository = appointmentRepository;
      }

      public void Handle(CreateAppointmentCommand message)
      {
         if (message.RoomChoices == null || message.RoomChoices.Count() == 0)
            throw new ArgumentException($"{nameof(message.RoomChoices)} must contain a value.");

         if (message.StaffChoices == null || message.StaffChoices.Count() == 0)
            throw new ArgumentException($"{nameof(message.StaffChoices)} must contain a value.");

         if (message.StartSlot < 0 || message.StartSlot > 31)
            throw new ArgumentException($"{nameof(message.StartSlot)} must be between 0 and 31.");

         if (message.NumberOfSlots < 1 || message.NumberOfSlots > 32)
            throw new ArgumentException($"{nameof(message.NumberOfSlots)} must be between 1 and 32.");

         if (message.Date == DateTime.MinValue)
            throw new ArgumentException($"{nameof(message.Date)} cannot be set to its min value.");

         var slotResult = _slotService.GetNextAvailableAppointmentSlots(
            message.Date.Date, 
            message.StartSlot, 
            message.StaffChoices.Select(x => ScheduleConverter.ConvertToDomain(x)).ToArray(), 
            message.RoomChoices, 
            message.NumberOfSlots);

         var appointment = Appointment.Create(
            message.ClinicalActivityId, 
            message.PatientId,
            message.PatientConditionId,
            slotResult.Item2, 
            slotResult.Item3,
            slotResult.Item1);

         _appointmentRepository.Store(appointment);
      }
   }
}
