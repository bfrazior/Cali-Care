using System;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Registration.Domain
{
   public class Admit : IAggregateRoot
   {
      public Guid Id { get; }

      public DateTime AdmitAt { get; }
      public Guid PatientId { get; }
   }
}
