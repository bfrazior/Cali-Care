using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using CaliCare.Infrastructure.Utilities;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Adapters.Repositories
{
   public class PhysicianRepository : IPhysicianRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "physicians.json");

      public IReadOnlyList<Physician> FindAll()
         => JsonConvert.DeserializeObject<Physician[]>(File.ReadAllText(_jsonPath)).ToList();

      public void Store(Physician[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));
   }
}
