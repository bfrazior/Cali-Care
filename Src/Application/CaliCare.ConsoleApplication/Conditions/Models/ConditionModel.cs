using System;

using CaliCare.Conditions.Common;

namespace CaliCare.ConsoleApplication.Conditions.Models
{
   public class ConditionModel
   {
      public Guid Id { get; set; }
      public ConditionClassification Classification { get; set; }
      public TopographyModel Topography { get; set; }
      public ConditionType Type { get; set; }
   }
}
