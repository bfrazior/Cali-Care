using System;

namespace CaliCare.ConsoleApplication.Views
{
   public static class ScheduleSubMenuView
   {
      public static void Show()
      {
         do
         {
            Console.WriteLine();
            Console.WriteLine("--Cali-Care Schedule--");
            Console.WriteLine("1. New Patient Consultations");
            Console.WriteLine("0. Return to Main Menu");
            Console.WriteLine();
            Console.Write("Enter Choice: ");

            int selectedChoice;
            if (!int.TryParse(Console.ReadLine().Trim(), out selectedChoice))
               continue;

            if (selectedChoice == 0)
               break;

            if (selectedChoice == 1)
               ConsultApptsSummaryListView.Show();

         } while (true);
      }
   }
}
