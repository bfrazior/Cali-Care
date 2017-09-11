using System;

using CaliCare.Conditions.Common;

namespace CaliCare.Conditions.Ports.DataTransferObjects
{
   public class TopographyDto
   {
      public TopographyClassification Classification { get; set; }
      public string Code { get; set; }
      public Guid Id { get; set; }
   }
}
