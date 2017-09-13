using System;

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

         var table = new ConsoleTable("Slot", "Length", "Room", "Patient", "Physician");

         var consults = ScheduleApi.GetAppointments("54321");
         foreach (var consult in consults)
         {
            table.AddRow(consult.Slot.StartAt, consult.Slot.LengthInMins, consult.Slot.RoomId, consult.PatientId, consult.Staff.AppointmentStaffId);
         }
         table.Write();

      }
   }
}
