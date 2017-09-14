using System;
using System.Linq;

using ConsoleTables;
using CaliCare.ConsoleApplication.WebApi;

namespace CaliCare.ConsoleApplication.Views
{
   public static class ConsultApptsSummaryListView
   {
      public static void Show()
      {
         Console.WriteLine();
         Console.WriteLine("--New Patient Consultations Summary List");

         var table = new ConsoleTable("Date", "Start Slot", "End Slot", "Room", "Patient", "Physician");

         var consults = ScheduleApi.GetAppointments("54321");
         foreach (var consult in consults)
         {
            var start = consult.Slots.Min(x => x.SlotNumber);
            var end = consult.Slots.Max(x => x.SlotNumber);
            table.AddRow(consult.Slots[0].Date, start, end, consult.RoomId, consult.PatientId, consult.Staff.AppointmentStaffId);
         }
         table.Write();

      }
   }
}
