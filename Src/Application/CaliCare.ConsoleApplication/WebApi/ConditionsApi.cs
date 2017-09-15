using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using CaliCare.Conditions.Ports.DataTransferObjects;

namespace CaliCare.ConsoleApplication.WebApi
{
   public static class ConditionsApi
   {
      public static PatientConditionDto CreateCondition(PatientConditionDto condition)
      {
         using (var client = new CaliCareHttpClient())
         {
            var byteContent = WebApiUtility.CreatePostContent(condition);

            var response = client.PostAsync("api/conditions/create/", byteContent).Result;
            if (!response.IsSuccessStatusCode)
               return null;

            var responseString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<PatientConditionDto>(responseString);
         }
      }

      public static PatientConditionDto GetCondition(Guid id)
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/conditions/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<PatientConditionDto>(responseString);
            }
         }

         return null;
      }

      public static TopographyDto GetTopography(Guid id)
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/conditions/topogs/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<TopographyDto>(responseString);
            }
         }

         return null;
      }

      public static List<TopographyDto> GetTopographies()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/conditions/topogs/").Result;

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
