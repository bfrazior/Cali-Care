using System;

namespace CaliCare.Schedule.Ports.DataTransferObjects
{
   public class ClinicalActivityDto
   {
      public Guid Id { get; set; }
      public string Code { get; set; }
      public string Group { get; set; }
      public string Name { get; set; }
   }
}
