using System;

namespace CaliCare.ConsoleApplication.Patients.Models
{
   public class PatientModel
   {
      public Guid Id { get; set; }
      public PatientNameModel PatientName { get; set; }
   }
}
