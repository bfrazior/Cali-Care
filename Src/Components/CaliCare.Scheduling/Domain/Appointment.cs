using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Scheduling.Common;

namespace CaliCare.Scheduling.Domain
{
   public class Appointment : IAggregateRoot
   {
      public Guid Id { get; }

      public Guid ClinicalActivityId { get; }
      public string Context { get; }
      public int LengthInMins { get; }
      public DateTime StartAt { get; }
      public AppointmentStatus Status { get; }
   }
}
