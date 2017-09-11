using System;

using CaliCare.ConsoleApplication.Conditions.Models;

namespace CaliCare.ConsoleApplication.Patients.Models
{
   public class PatientDetailsModel
   {
      public Guid Id { get; set; }
      public ConditionModel[] PatientConditions { get; set; }
   }
}
