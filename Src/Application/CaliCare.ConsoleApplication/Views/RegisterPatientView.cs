﻿using System;
using System.Linq;

using CaliCare.Conditions.Common;
using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.ConsoleApplication.WebApi;
using CaliCare.Patients.Ports.DataTransferObjects;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Resources.Domain;
using CaliCare.Schedule.Common;

namespace CaliCare.ConsoleApplication.Views
{
   public static class RegisterPatientInput
   {
      public static void Show()
      {
         Console.WriteLine();
         Console.WriteLine("--Cali-Care Patient Registration--");

         var patientName = PatientNameInput();
         var condition = PatientConditionInput();

         var admittedPatient = AdmitPatient(patientName, condition);

         if (admittedPatient != null)
            ScheduleConsult(admittedPatient.Item1.Id, admittedPatient.Item2.Id);
      }

      private static PatientNameDto PatientNameInput()
      {
         var patientName = new PatientNameDto();

         Console.WriteLine();
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

         return patientName;
      }

      private static PatientConditionDto PatientConditionInput()
      {

         Console.WriteLine();
         Console.WriteLine("Patient Initial Condition");
         Console.WriteLine("---------------------------------");

         var conditionType = PatientConditionTypeInput();

         if (conditionType == ConditionType.Flu)
            return EmptyNonCancerPatientCondition(conditionType);

         var cancerConditionClassification = CancerConditionClassificationInput();
         var cancerTopography = CancerTopographyInput();

         return EmptyCancerPatientCondition(conditionType, cancerConditionClassification, cancerTopography);
      }

      private static ConditionType PatientConditionTypeInput()
      {
         ConditionType conditionType;
         do
         {
            Console.WriteLine();
            Console.Write("Enter a Condition Type [Cancer/Flu]: ");
            var enteredValue = Console.ReadLine().Trim();

            if (Enum.TryParse(enteredValue, true, out conditionType))
               break;

         } while (true);

         return conditionType;
      }

      private static ConditionClassification CancerConditionClassificationInput()
      {
         ConditionClassification conditionClassification;
         do
         {
            Console.WriteLine();
            Console.Write("Enter a Cancer Condition Classification [Primary/Secondary]: ");
            var enteredValue = Console.ReadLine().Trim();

            if (Enum.TryParse(enteredValue, true, out conditionClassification))
               break;

         } while (true);

         return conditionClassification;
      }

      private static TopographyDto CancerTopographyInput()
      {
         TopographyDto topography;
         var topogs = ConditionsApi.GetTopographies();
         do
         {
            Console.WriteLine();
            Console.WriteLine("Topography List");
            Console.WriteLine("---------------------------------");

            topogs.ForEach(x => Console.WriteLine($"- {x.Code}"));
            Console.WriteLine();
            Console.Write("Enter a topography code: ");
            var enteredValue = Console.ReadLine().Trim();

            topography = topogs.Where(x => string.Equals(x.Code, enteredValue, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

            if (topography != null)
               break;

         } while (true);

         return topography;
      }

      private static Tuple<PatientDto, PatientConditionDto> AdmitPatient(PatientNameDto name, PatientConditionDto condition)
      {
         Console.WriteLine();
         Console.WriteLine("Confirm Patient Registration");
         Console.WriteLine("---------------------------------");
         Console.WriteLine($"Name: {name.LastName}, {name.FirstName}, {name.MiddleName}");
         Console.WriteLine($"Prefered Name: {name.PreferredName}");
         Console.WriteLine($"Condition Type: {condition.Type.ToString()}");
         Console.WriteLine($"Condition Classification: {condition.Classification.ToString()}");

         if (condition.TopogId.HasValue)
         {
            var topography = ConditionsApi.GetTopography(condition.TopogId.Value);
            Console.WriteLine($"Topography Code: {topography.Code}");
         }

         Console.WriteLine();
         Console.Write("Admit Patient [Y/N]: ");
         var admitValue = Console.ReadLine().Trim();

         if (!string.Equals(admitValue, "Y", StringComparison.OrdinalIgnoreCase))
            return null;

         var createdPatient = PatientsApi.CreatePatient(name);
         if (createdPatient == null)
            return null;

         condition.PatientId = createdPatient.Id;
         var createdCondition = ConditionsApi.CreateCondition(condition);

         return new Tuple<PatientDto, PatientConditionDto>(createdPatient, createdCondition);
      }

      private static void ScheduleConsult(Guid patientId, Guid conditionId)
      {
         Console.WriteLine();
         Console.Write("Schedule New Patient Consultation [Y/N]: ");
         var consultValue = Console.ReadLine().Trim();

         if (!string.Equals(consultValue, "Y", StringComparison.OrdinalIgnoreCase))
            return;

         var department = ResourcesApi.GetDepartments().First();
         var clinicalActivity = ScheduleApi.GetClinicalActivityByCode("54321");

         var createAppointmentDto = new CreateAppointmentDto()
         {
            ClinicalActivityId = clinicalActivity.Id,
            Date = DateTime.Now.AddDays(1),
            DepartmentId = department.Id,
            NumberOfSlots = 32,
            PatientId = patientId,
            PatientConditionId = conditionId,
            StartSlot = 0 
         };
         ScheduleApi.CreateConsultation(createAppointmentDto);
      }

      private static PatientConditionDto EmptyNonCancerPatientCondition(ConditionType type)
      {
         return new PatientConditionDto()
         {
            Classification = ConditionClassification.NonCancer,
            Id = Guid.Empty,
            PatientId = Guid.Empty,
            Type = type
         };
      }

      private static PatientConditionDto EmptyCancerPatientCondition(
         ConditionType type, 
         ConditionClassification classification, 
         TopographyDto topography)
      {
         return new PatientConditionDto()
         {
            Classification = classification,
            Id = Guid.Empty,
            PatientId = Guid.Empty,
            TopogId = topography.Id,
            Type = type
         };
      }
   }
}
