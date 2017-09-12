using System;

using Newtonsoft.Json;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.ConsoleApplication.Conditions.Models;
using CaliCare.ConsoleApplication.WebApi;

namespace CaliCare.ConsoleApplication.Conditions.Services
{
   public static class ConditionModelFactory
   {
      public static ConditionModel Create(PatientConditionDto conditionDto)
      {
         return new ConditionModel()
         {
            Classification = conditionDto.Classification,
            Id = conditionDto.Id,
            Topography = GetTopography(conditionDto.TopogId),
            Type = conditionDto.Type
         };
      }

      private static TopographyModel GetTopography(Guid? topogId)
      {
         if (!topogId.HasValue)
            return null;

         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/conditions/topogs/{topogId}").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return TopographyModelFactory.Create(JsonConvert.DeserializeObject<TopographyDto>(responseString));
            }
         }
         return null;
      }
   }
}
