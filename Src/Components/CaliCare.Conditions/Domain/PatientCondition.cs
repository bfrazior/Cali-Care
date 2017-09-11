using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Common;

namespace CaliCare.Conditions.Domain
{
   public class PatientCondition : IAggregateRoot
   {
      public Guid Id { get; }
      public ConditionClassification Classification { get; }
      public Guid PatientId { get; }
      public Guid? TopogId { get; }
      public ConditionType Type { get; }

      public PatientCondition(Guid id, ConditionType type, ConditionClassification classification, Guid patientId, Guid? topogId = null)
      {
         if (patientId == Guid.Empty)
            throw new ArgumentException($"{nameof(patientId)} cannot be empty");

         if (type == ConditionType.Flu && classification != ConditionClassification.NonCancer)
            throw new ArgumentException($"{nameof(type)} cannot be set to cancer classification.");

         if (type == ConditionType.Flu && topogId.HasValue)
            throw new ArgumentException($"{nameof(type)} cannot be set to a topography.");

         if (type == ConditionType.Cancer && !topogId.HasValue)
            throw new ArgumentException($"{nameof(type)} must be assigned a topography.");

         Id = id;
         Type = type;
         Classification = classification;
         PatientId = patientId;
         TopogId = topogId;
      }

      public static PatientCondition Create(ConditionType type, ConditionClassification classification, Guid patientId, Guid? topogId = null)
         => new PatientCondition(Guid.NewGuid(), type, classification, patientId, topogId);
   }
}
