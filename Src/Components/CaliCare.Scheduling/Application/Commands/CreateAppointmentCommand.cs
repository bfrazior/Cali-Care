using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Commands
{
   public class CreateAppointmentCommand : ICommand
   {
      public Guid ClinicalActivityId { get; set; }
      public Guid PatientId { get; set; }
      public AppointmentStaffDto Staff { get; set; }
      public AppointmentSlotDto Slot { get; set; }
   }
}
