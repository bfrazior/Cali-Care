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
      {
         try { return JsonConvert.DeserializeObject<Physician[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<Physician>(); }
      }

      public void Store(Physician physician)
      {
         var physicians = FindAll().ToList();
         physicians.Add(physician);
         Store(physicians.ToArray());
      }

      public void Store(Physician[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));
   }
}
