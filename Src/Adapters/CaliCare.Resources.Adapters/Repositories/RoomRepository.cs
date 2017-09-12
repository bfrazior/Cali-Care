using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using CaliCare.Infrastructure.Utilities;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Adapters.Repositories
{
   public class RoomRepository : IRoomRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "rooms.json");

      public IReadOnlyList<Room> FindAll()
         => JsonConvert.DeserializeObject<Room[]>(File.ReadAllText(_jsonPath)).ToList();

      public IReadOnlyList<Room> FindAll(Guid departmentId)
         => FindAll().Where(x => x.DepartmentId == departmentId).ToList();

      public void Store(Room[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));
   }
}
