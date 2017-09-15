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

         var table = new ConsoleTable("Date", "Start Slot", "End Slot", "Room", "Patient", "Physician", "Condition", "Topog");

         var consults = ScheduleApi.GetAppointments("54321");
         foreach (var consult in consults)
         {
            var slots = ScheduleApi.GetAppointmentSlots(consult.Date.Date, consult.Id);
            var start = slots.Min(x => x.SlotNumber);
            var end = slots.Max(x => x.SlotNumber);

            var patient = PatientsApi.GetPatient(consult.PatientId);
            var patientName = $"{patient.Name.LastName}, {patient.Name.FirstName} {patient.Name.MiddleName}";

            var physician = ResourcesApi.GetPhysician(consult.Staff);
            var physicianName = $"{physician.Name.LastName}, {physician.Name.FirstName} {physician.Name.MiddleName}";

            var room = ResourcesApi.GetRoom(consult.RoomId);

            var conditionType = string.Empty;
            var topogCode = string.Empty;
            if (consult.PatientConditionId.HasValue)
            {
               var condition = ConditionsApi.GetCondition(consult.PatientConditionId.Value);
               conditionType = condition.Type.ToString();

               if (condition.TopogId.HasValue)
                  topogCode = ConditionsApi.GetTopography(condition.TopogId.Value).Code;
            }

            table.AddRow(consult.Date.ToShortDateString(), start, end, room.Name, patientName, physicianName, conditionType, topogCode);
         }

         table.Write();
      }
   }
}
