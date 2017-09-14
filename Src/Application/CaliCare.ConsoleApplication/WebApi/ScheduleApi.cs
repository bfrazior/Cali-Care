using Newtonsoft.Json;

using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.ConsoleApplication.WebApi
{
   public static class ScheduleApi
   {
      public static void CreateAppointment(CreateAppointmentDto createAppointmentDto)
      {
         using (var client = new CaliCareHttpClient())
         {
            var byteContent = WebApiUtility.CreatePostContent(createAppointmentDto);
            var response = client.PostAsync("api/schedule/appointments/create", byteContent).Result;
         }
      }

      public static AppointmentDto[] GetAppointments(string clinicalActivityCode)
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/schedule/appointments/{clinicalActivityCode}").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<AppointmentDto[]>(responseString);
            }
         }

         return new AppointmentDto[0];
      }

      public static ClinicalActivityDto GetClinicalActivityByCode(string code)
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/schedule/activities/{code}").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<ClinicalActivityDto>(responseString);
            }
         }

         return null;
      }
   }
}
