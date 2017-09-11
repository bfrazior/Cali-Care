using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Newtonsoft.Json;

using CaliCare.Conditions.Common;
using CaliCare.Conditions.Domain;
using CaliCare.Conditions.Ports.Repositories;
using CaliCare.Infrastructure.Utilities;

namespace CaliCare.Conditions.Adapters.Repositories
{
   public class ConditionRepository : IConditionRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "conditions.json");

      public PatientCondition Find(Guid id)
         => FindAll()
            .Where(x => x.Id == id)
            .SingleOrDefault();

      public IReadOnlyList<PatientCondition> FindAll()
      {
         try { return JsonConvert.DeserializeObject<PatientCondition[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<PatientCondition>(); }
      }

      public IReadOnlyList<PatientCondition> FindAll(ConditionClassification classification)
         => FindAll()
            .Where(x => x.Classification == classification)
            .ToList();

      public void Store(PatientCondition condition)
      {
         var conditions = FindAll().ToList();
         conditions.Add(condition);
         Store(conditions.ToArray());
      }

      public void Store(PatientCondition[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));
   }
}
