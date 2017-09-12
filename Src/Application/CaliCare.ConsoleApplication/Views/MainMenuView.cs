using System;

namespace CaliCare.ConsoleApplication.Views
{
   public static class MainMenuView
   {
      public static void Show()
      {
         do
         {
            Console.WriteLine();
            Console.WriteLine("--Cali-Care Main Menu--");
            Console.WriteLine("1. Patients");
            Console.WriteLine("2. Resources");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Enter Choice: ");

            int selectedChoice;
            if (!int.TryParse(Console.ReadLine().Trim(), out selectedChoice))
               continue;

            if (selectedChoice == 0)
               break;

            if (selectedChoice == 1)
               PatientSubMenuView.Show();

            if (selectedChoice == 2)
               ResourcesSubMenuView.Show();

         } while (true);
      }
   }
}
