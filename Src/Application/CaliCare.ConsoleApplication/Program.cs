using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.ConsoleApplication.Conditions.Models;
using CaliCare.ConsoleApplication.Conditions.Services;
using CaliCare.ConsoleApplication.Views;
using ConsoleTables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaliCare.ConsoleApplication
{
   class Program
   {
      private static readonly Uri _apiBaseAddress = new Uri("http://localhost:60098/");

      static void Main(string[] args)
      {
         MainMenu.Show();
      }



      private static List<TopographyModel> GetTopographyModels()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/conditions/topogs/").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<TopographyDto[]>(responseString).Select(x => TopographyModelFactory.Create(x)).ToList();
            }
         }
         return new List<TopographyModel>();
      }

      private static List<ConditionModel> GetConditionModels()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync("api/conditions").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<PatientConditionDto[]>(responseString)
                  .Select(x => ConditionModelFactory.Create(x))
                  .ToList();
            }
         }
         return new List<ConditionModel>();
      }

      private static void ResourcesMenu()
      {
         Console.WriteLine();
         Console.WriteLine("--Cali-Care Resources--");
         Console.WriteLine("1. Physicians");
         Console.WriteLine("2. Departments");
         Console.WriteLine("3. Treatment Machines");
         Console.WriteLine("0. Return to Main Menu");
         Console.Write("Enter Choice: ");

         int choice = 0;
         if (!int.TryParse(Console.ReadLine().Trim(), out choice))
            ResourcesMenu();
      }

      private static void ConditionsMenu()
      {
         Console.WriteLine();
         Console.WriteLine("--Cali-Care Conditions--");
         Console.WriteLine("1. List Conditions");
         //Console.WriteLine("2. Add Condition");
         //Console.WriteLine("3. Add Topography");
         Console.WriteLine("0. Return to Main Menu");
         Console.Write("Enter Choice: ");

         int choice = 0;
         if (!int.TryParse(Console.ReadLine().Trim(), out choice))
            ConditionsMenu();

         switch (choice)
         {
            case 0:
               MainMenu.Show();
               break;
            case 1:
               GetConditions();
               break;
            default:
               ConditionsMenu();
               break;
         }
         ConditionsMenu();
      }

      private static void GetConditions()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync("api/conditions").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               var conditions = JsonConvert.DeserializeObject<PatientConditionDto[]>(responseString).ToList();
               var topogs = GetTopographies();

               var table = new ConsoleTable("Type", "Classification", "Topography");
               foreach(var condition in conditions)
               {
                  var topog = topogs.Where(x => x.Id == condition.TopogId).SingleOrDefault();
                  table.AddRow(condition.Type.ToString(), condition.Classification.ToString(), topog?.Code);
               }

               Console.WriteLine("--Conditions List");
               table.Write();
            }
         }
      }

      private static List<TopographyDto> GetTopographies()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync("api/conditions/topogs").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<TopographyDto[]>(responseString).ToList();
            }
         }
         return new List<TopographyDto>();
      }
   }
}
