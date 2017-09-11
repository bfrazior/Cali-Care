using CaliCare.ConsoleApplication.Patients.Models;
using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.ConsoleApplication.Patients.Services
{
   public static class PatientModelFactory
   {
      public static PatientModel CreatePatientModel(PatientDto patientDto)
      {
         PatientNameModel patientName = null;
         if (patientDto.Name != null)
         {
            patientName = new PatientNameModel()
            {
               FirstName = patientDto.Name.FirstName,
               LastName = patientDto.Name.LastName,
               MiddleName = patientDto.Name.MiddleName,
               PreferredName = patientDto.Name.PreferredName
            };
         }

         return new PatientModel()
         {
            Id = patientDto.Id,
            PatientName = patientName
         };
      }
   }
}
