using System;

using CaliCare.Conditions.Common;

namespace CaliCare.ConsoleApplication.Conditions.Models
{
   public class TopographyModel
   {
      public Guid Id { get; set; }
      public TopographyClassification Classification { get; set; }
      public string Code { get; set; }
   }
}
