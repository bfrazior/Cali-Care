using System;

using CaliCare.Conditions.Common;

namespace CaliCare.Conditions.Ports.DataTransferObjects
{
   public class PatientConditionDto
   {
      public Guid Id { get; set; }
      public ConditionClassification Classification { get; set; }
      public Guid PatientId { get; set; }
      public Guid? TopogId { get; set; }
      public ConditionType Type { get; set; }
   }
}
