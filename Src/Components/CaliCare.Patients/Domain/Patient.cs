using System;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Patients.Domain
{
   public class Patient : IAggregateRoot
   {
      public Guid Id { get; }
      public PatientName Name { get; }

      public Patient(Guid id, PatientName name)
      {
         Id = id;
         Name = name;
      }

      public static Patient Create(PatientName name)
         => new Patient(Guid.NewGuid(), name);
   }
}
