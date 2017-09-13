using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using CaliCare.Infrastructure.Utilities;
using CaliCare.Scheduling.Domain;
using CaliCare.Scheduling.Ports.Repositories;


namespace CaliCare.Scheduling.Adapters.Repositories
{
   public class ClinicalActivityRepository : IClinicalActivityRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "clinicalActivities.json");

      public IReadOnlyList<ClinicalActivity> FindAll()
         => JsonConvert.DeserializeObject<ClinicalActivity[]>(File.ReadAllText(_jsonPath)).ToList();

      public void Store(ClinicalActivity[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));
   }
}
