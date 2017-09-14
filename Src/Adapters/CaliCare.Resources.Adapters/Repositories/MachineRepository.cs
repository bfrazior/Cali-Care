using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using CaliCare.Resources.Ports.Repositories;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Common;
using CaliCare.Infrastructure.Utilities;

namespace CaliCare.Resources.Adapters.Repositories
{
   public class MachineRepository : IMachineRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "machines.json");

      public IReadOnlyList<Machine> FindAll()
      {
         try { return JsonConvert.DeserializeObject<Machine[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<Machine>(); }
      }

      public IReadOnlyList<Machine> FindAll(MachineCapability capability)
         => FindAll().Where(x => x.Characterization.Capability == capability).ToList();

      public Machine FindByRoomId(Guid roomId)
         => FindAll().Where(x => x.RoomId == roomId).SingleOrDefault();

      public void Store(Machine[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));
   }
}
