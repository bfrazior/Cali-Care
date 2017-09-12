using CaliCare.Conditions.Common;
using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.ConsoleApplication.Conditions.Models;
using CaliCare.ConsoleApplication.Conditions.Services;
using CaliCare.ConsoleApplication.Patients.Services;
using CaliCare.ConsoleApplication.Utilities;
using CaliCare.Patients.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.DataTransferObjects;
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
         MainMenu();
      }

      private static void MainMenu()
      {
         Console.WriteLine();
         Console.WriteLine("--Cali-Care Main Menu--");
         Console.WriteLine("1. Patients");
         Console.WriteLine("2. Resources");
         Console.WriteLine("3. Conditions");
         Console.WriteLine("0. Exit");
         Console.Write("Enter Choice: ");

         int choice = 0;
         if (!int.TryParse(Console.ReadLine().Trim(), out choice))
            MainMenu();

         switch (choice)
         {
            case 0:
               return;
            case 1:
               PatientsMenu();
               break;
            case 3:
               ConditionsMenu();
               break;
            default:
               MainMenu();
               break;
         } 
      }

      private static void PatientsMenu()
      {
         Console.WriteLine();
         Console.WriteLine("--Cali-Care Patients--");
         Console.WriteLine("1. List Patients");
         Console.WriteLine("2. Register Patient");
         Console.WriteLine("0. Return to Main Menu");
         Console.Write("Enter Choice: ");

         int choice = 0;
         if (!int.TryParse(Console.ReadLine().Trim(), out choice))
            PatientsMenu();

         switch (choice)
         {
            case 0:
               MainMenu();
               break;
            case 1:
               GetPatients();
               break;
            case 2:
               RegisterPatientMenu();
               break;
            default:
               PatientsMenu();
               break;
         }
         PatientsMenu();
      }

      private static void RegisterPatientMenu()
      {
         Console.WriteLine();
         Console.WriteLine("--Cali-Care Patient Registration--");

         var patientName = new PatientNameDto();
         Console.WriteLine("Patient Name");
         Console.WriteLine("----------------------------------");
         Console.Write("Last Name: ");
         patientName.LastName = Console.ReadLine().Trim();
         Console.Write("First Name: ");
         patientName.FirstName = Console.ReadLine().Trim();
         Console.Write("Middle Name: ");
         patientName.MiddleName = Console.ReadLine().Trim();
         Console.Write("Preferred Name: ");
         patientName.PreferredName = Console.ReadLine().Trim();

         Console.WriteLine();
         Console.WriteLine("Patient Initial Condition");
         Console.WriteLine("---------------------------------");

         PatientConditionDto condition = null;
         TopographyModel topography = null;
         do
         {
            Console.Write("Enter a Condition Type [Cancer/Flu]: ");
            var enteredValue = Console.ReadLine().Trim();

            ConditionType conditionType;
            if (!Enum.TryParse(enteredValue, true, out conditionType))
               continue;

            if (conditionType == ConditionType.Flu)
            {
               condition = new PatientConditionDto()
               {
                  Classification = ConditionClassification.NonCancer,
                  Id = Guid.Empty,
                  PatientId = Guid.Empty,
                  Type = ConditionType.Flu
               };
               break;
            }

            if (conditionType == ConditionType.Cancer)
            {
               ConditionClassification conditionClassification;
               do
               {
                  Console.WriteLine();
                  Console.WriteLine("Enter a Cancer Condition Classification [Primary/Secondary]: ");
                  enteredValue = Console.ReadLine().Trim();

                  if (Enum.TryParse(enteredValue, true, out conditionClassification))
                     break;

               } while (true);
        
               do
               {
                  var topogs = GetTopographyModels();
                  Console.WriteLine();
                  Console.WriteLine("Topography code list");
                  topogs.ForEach(x => Console.WriteLine($"- {x.Code}"));
                  Console.WriteLine();
                  Console.Write("Enter a topography code: ");
                  enteredValue = Console.ReadLine().Trim();

                  topography = topogs.Where(x => string.Equals(x.Code, enteredValue, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                  if (topography != null)
                     break;

               } while (true);

               condition = new PatientConditionDto()
               {
                  Classification = conditionClassification,
                  Id = Guid.Empty,
                  PatientId = Guid.Empty,
                  TopogId = topography.Id,
                  Type = ConditionType.Cancer
               };
               break;
            }
         } while (true);

         Console.WriteLine();
         Console.WriteLine("Confirm Patient Registration");
         Console.WriteLine("---------------------------------");
         Console.WriteLine($"Name: {patientName.LastName}, {patientName.FirstName}, {patientName.MiddleName}");
         Console.WriteLine($"Prefered Name: {patientName.PreferredName}");
         Console.WriteLine($"Condition Type: {condition.Type.ToString()}");
         Console.WriteLine($"Condition Classification: {condition.Classification.ToString()}");

         if (condition.TopogId.HasValue)
            Console.WriteLine($"Topography Code: {topography.Code}");

         Console.WriteLine();
         Console.Write("Admit Patient [Y/N]: ");
         var admitValue = Console.ReadLine().Trim();

         if (string.Equals(admitValue, "Y", StringComparison.OrdinalIgnoreCase))
            AdmitPatient(patientName, condition);
      }

      private static void AdmitPatient(PatientNameDto patientName, PatientConditionDto condition)
      {
         using (var client = new CaliCareHttpClient())
         {
            var createdPatient = CreatePatient(client, patientName);
            if (createdPatient == null)
               return;

            condition.PatientId = createdPatient.Id;
            var createdCondition = CreateCondition(client, condition);
         }
      }

      private static PatientDto CreatePatient(CaliCareHttpClient client, PatientNameDto name)
      {
         var byteContent = WebApiUtility.CreatePostContent(name);

         var response = client.PostAsync("api/patients/create/", byteContent).Result;
         if (!response.IsSuccessStatusCode)
            return null;

         var responseString = response.Content.ReadAsStringAsync().Result;
         return JsonConvert.DeserializeObject<PatientDto>(responseString);
      }

      private static PatientConditionDto CreateCondition(CaliCareHttpClient client, PatientConditionDto condition)
      {
         var byteContent = WebApiUtility.CreatePostContent(condition);

         var response = client.PostAsync("api/conditions/create/", byteContent).Result;
         if (!response.IsSuccessStatusCode)
            return null;

         var responseString = response.Content.ReadAsStringAsync().Result;
         return JsonConvert.DeserializeObject<PatientConditionDto>(responseString);
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
               MainMenu();
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

      private static void GetPatients()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync("api/patients").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;

               var patients = JsonConvert.DeserializeObject<PatientDto[]>(responseString)
                  .Select(x => PatientModelFactory.CreatePatientModel(x))
                  .ToList();

               var table = new ConsoleTable("Name", "Name Preference");
               foreach (var patient in patients)
               {
                  var fullName = string.Empty;
                  if (patient.PatientName != null)
                     fullName = $"{patient.PatientName.LastName}, {patient.PatientName.FirstName} {patient.PatientName.MiddleName}";

                  table.AddRow(fullName, patient.PatientName.PreferredName);
               }

               Console.WriteLine("--Patients List");
               table.Write();
            }
         }
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

      private static void GetDepartments()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync("api/resources/departments").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               var departments = JsonConvert.DeserializeObject<DepartmentDto[]>(responseString).ToList();

               Console.WriteLine();
               Console.WriteLine("---------------------Departments------------------------");
               Console.WriteLine();
               Console.WriteLine("Name");
               Console.WriteLine("-----------------------------------------------------------");
               departments.ForEach(x => Console.WriteLine($"{x.Name}"));

               Console.ReadLine();
            }
         }
      }
   }
}
