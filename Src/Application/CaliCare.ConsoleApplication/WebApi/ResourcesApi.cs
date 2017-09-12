using Newtonsoft.Json;

using CaliCare.Resources.Ports.DataTransferObjects;
using System;

namespace CaliCare.ConsoleApplication.WebApi
{
   public static class ResourcesApi
   {
      public static DepartmentDto[] GetDepartments()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/resources/departments").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<DepartmentDto[]>(responseString);
            }
         }

         return new DepartmentDto[0];
      }

      public static RoomDto[] GetRooms(Guid id)
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/resources/rooms/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<RoomDto[]>(responseString);
            }
         }

         return new RoomDto[0];
      }

      public static MachineDto GetMachineInRoom(Guid id)
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync($"api/resources/machines/room/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<MachineDto>(responseString);
            }
         }

         return null;
      }

      public static PhysicianDto[] GetAllPysicians()
      {
         using (var client = new CaliCareHttpClient())
         {
            var response = client.GetAsync("api/resources/physicians").Result;

            if (response.IsSuccessStatusCode)
            {
               var responseString = response.Content.ReadAsStringAsync().Result;
               return JsonConvert.DeserializeObject<PhysicianDto[]>(responseString);
            }
         }

         return new PhysicianDto[0];
      }
   }
}
