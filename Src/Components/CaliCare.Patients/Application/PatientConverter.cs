using CaliCare.Patients.Domain;
using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.Patients.Application
{
   internal static class PatientConverter
   {
      public static Patient ConvertToDomain(PatientDto patientDto)
         => patientDto == null ? null : new Patient(
            patientDto.Id, 
            ConvertToDomain(patientDto.Name));

      public static PatientName ConvertToDomain(PatientNameDto patientNameDto)
         => patientNameDto == null ? null : new PatientName(
            patientNameDto.FirstName, 
            patientNameDto.MiddleName, 
            patientNameDto.LastName, 
            patientNameDto.PreferredName);

      public static PatientDto ConvertToDto(Patient patient)
         => patient == null ? null : new PatientDto()
         {
            Id = patient.Id,
            Name = ConvertToDto(patient.Name)
         };

      public static PatientNameDto ConvertToDto(PatientName patientName)
         => patientName == null ? null : new PatientNameDto()
         {
            FirstName = patientName.FirstName,
            LastName = patientName.LastName,
            MiddleName = patientName.MiddleName,
            PreferredName = patientName.PreferredName
         };
   }
}
