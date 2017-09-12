using System;

namespace CaliCare.ConsoleApplication.Views
{
   public static class ResourcesSubMenuView
   {
      public static void Show()
      {
         do
         {
            Console.WriteLine();
            Console.WriteLine("--Cali-Care Resources--");
            Console.WriteLine("1. Physician List");
            Console.WriteLine("2. Department Summary List");
            Console.WriteLine("0. Return to Main Menu");
            Console.WriteLine();
            Console.Write("Enter Choice: ");

            int selectedChoice;
            if (!int.TryParse(Console.ReadLine().Trim(), out selectedChoice))
               continue;

            if (selectedChoice == 0)
               break;

            if (selectedChoice == 1)
               PhysicianListView.Show();

            if (selectedChoice == 2)
               DepartmentSummaryListView.Show();

         } while (true);
      }
   }
}
