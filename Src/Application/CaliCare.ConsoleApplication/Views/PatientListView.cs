using System;

using CaliCare.ConsoleApplication.WebApi;
using ConsoleTables;

namespace CaliCare.ConsoleApplication.Views
{
   public static class PatientListView
   {
      public static void Show()
      {
         var patients = PatientsApi.GetPatients();

         var table = new ConsoleTable("Name", "Name Preference");
         foreach (var patient in patients)
         {
            var fullName = string.Empty;
            if (patient.Name != null)
               fullName = $"{patient.Name.LastName}, {patient.Name.FirstName} {patient.Name.MiddleName}";

            table.AddRow(fullName, patient.Name.PreferredName);
         }

         Console.WriteLine();
         Console.WriteLine("--Patient List");
         table.Write();
      }
   } 
}
