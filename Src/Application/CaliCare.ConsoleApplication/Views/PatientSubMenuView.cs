using System;

namespace CaliCare.ConsoleApplication.Views
{
   public static class PatientSubMenuView
   {
      public static void Show()
      {
         do
         {
            Console.WriteLine();
            Console.WriteLine("--Cali-Care Patients--");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. Patient List");
            Console.WriteLine("0. Return to Main Menu");
            Console.WriteLine();
            Console.Write("Enter Choice: ");

            int selectedChoice;
            if (!int.TryParse(Console.ReadLine().Trim(), out selectedChoice))
               continue;

            if (selectedChoice == 0)
               break;

            if (selectedChoice == 1)
               RegisterPatientInput.Show();

            if (selectedChoice == 2)
               PatientListView.Show();

         } while (true);
      }
   }
}
