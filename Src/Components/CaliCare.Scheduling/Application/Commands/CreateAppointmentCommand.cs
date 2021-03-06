﻿using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Commands
{
   public class CreateAppointmentCommand : ICommand
   {
      public Guid ClinicalActivityId { get; set; }
      public DateTime Date { get; set; }
      public Guid PatientConditionId { get; set; }
      public Guid PatientId { get; set; }
      public Guid[] RoomChoices { get; set; }
      public int NumberOfSlots { get; set; }
      public int StartSlot { get; set; }
      public AppointmentStaffDto[] StaffChoices { get; set; }
   }
}
