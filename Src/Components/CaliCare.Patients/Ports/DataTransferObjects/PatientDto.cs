using System;

namespace CaliCare.Patients.Ports.DataTransferObjects
{
   public class PatientDto
   {
      public Guid Id { get; set; }
      public PatientNameDto Name { get; set; }
   }

   public class PatientNameDto
   {
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }
      public string PreferredName { get; set; }
   }
}
