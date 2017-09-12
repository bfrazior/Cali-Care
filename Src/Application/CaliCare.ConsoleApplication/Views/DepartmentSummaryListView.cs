using System;

using CaliCare.ConsoleApplication.WebApi;
using ConsoleTables;

namespace CaliCare.ConsoleApplication.Views
{
   public static class DepartmentSummaryListView
   {
      public static void Show()
      {
         Console.WriteLine();
         Console.WriteLine("--Department Summary List");

         var departments = ResourcesApi.GetAllDepartments();
         foreach(var department in departments)
         {
            var table = new ConsoleTable("Department Name");
            table.Options.EnableCount = false;
            table.AddRow(department.Name);

            var rooms = ResourcesApi.GetRooms(department.Id);
            var tableDetails = new ConsoleTable("Room", "Machine Name", "Machine Capability");
            foreach(var room in rooms)
            {
               var machineDetails = new Tuple<string, string>(string.Empty, string.Empty);
               var machine = ResourcesApi.GetMachineInRoom(room.Id);
               if (machine != null)
                  machineDetails = new Tuple<string, string>(machine.Name, machine.Characterization.Capability.ToString());

               tableDetails.AddRow(room.Name, machineDetails.Item1, machineDetails.Item2);
            }

            table.Write();
            tableDetails.Write();
         }
      }
   }
}
