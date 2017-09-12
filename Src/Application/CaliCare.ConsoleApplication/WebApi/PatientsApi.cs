using Newtonsoft.Json;

using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.ConsoleApplication.WebApi
{
   public static class PatientsApi
   {
      public static PatientDto CreatePatient(PatientNameDto name)
      {
         using (var client = new CaliCareHttpClient())
         {
            var byteContent = WebApiUtility.CreatePostContent(name);

            var response = client.PostAsync("api/patients/create/", byteContent).Result;
            if (!response.IsSuccessStatusCode)
               return null;

            var responseString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<PatientDto>(responseString);
         }
      }

      public static PatientDto[] GetAllPatients()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync("api/patients").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<PatientDto[]>(responseString);
            }
         }

         return new PatientDto[0];
      }
   }
}
