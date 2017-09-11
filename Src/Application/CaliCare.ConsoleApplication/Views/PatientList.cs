using System;

using CaliCare.ConsoleApplication.WebApi;
using ConsoleTables;

namespace CaliCare.ConsoleApplication.Views
{
   public static class PatientList
   {
      public static void Show()
      {
         var patients = PatientsApi.GetAllPatients();

         var table = new ConsoleTable("Name", "Name Preference");
         foreach (var patient in patients)
         {
            var fullName = string.Empty;
            if (patient.Name != null)
               fullName = $"{patient.Name.LastName}, {patient.Name.FirstName} {patient.Name.MiddleName}";

            table.AddRow(fullName, patient.Name.PreferredName);
         }

         Console.WriteLine("--Patients List");
         table.Write();
      }
   } 
}
