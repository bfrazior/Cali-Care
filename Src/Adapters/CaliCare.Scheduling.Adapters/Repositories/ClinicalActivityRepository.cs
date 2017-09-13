using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using CaliCare.Infrastructure.Utilities;
using CaliCare.Schedule.Domain;
using CaliCare.Schedule.Ports.Repositories;

namespace CaliCare.Schedule.Adapters.Repositories
{
   public class ClinicalActivityRepository : IClinicalActivityRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "clinicalActivities.json");

      public ClinicalActivity Find(string code)
         => FindAll().Where(x => string.Equals(x.Code, code, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

      public IReadOnlyList<ClinicalActivity> FindAll()
      {
         try { return JsonConvert.DeserializeObject<ClinicalActivity[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<ClinicalActivity>(); }
      }

      public void Store(ClinicalActivity[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));
   }
}
