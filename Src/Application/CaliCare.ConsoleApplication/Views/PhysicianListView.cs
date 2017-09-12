using System;

using ConsoleTables;

using CaliCare.ConsoleApplication.WebApi;

namespace CaliCare.ConsoleApplication.Views
{
   public static class PhysicianListView
   {
      public static void Show()
      {
         var physicians = ResourcesApi.GetAllPysicians();

         var table = new ConsoleTable("Name", "User Name", "Roles");
         foreach (var physician in physicians)
         {
            var fullName = string.Empty;
            var userName = string.Empty;
            if (physician.Name != null)
            {
               fullName = $"{physician.Name.LastName}, {physician.Name.FirstName} {physician.Name.MiddleName}";
               userName = physician.Name.UserName;
            }

            var roles = string.Empty;
            if (physician.Roles != null)
               roles = string.Join(", ", physician.Roles);

            table.AddRow(fullName, userName, roles);
         }

         Console.WriteLine();
         Console.WriteLine("--Physician List");
         table.Write();
      }
   }
}
