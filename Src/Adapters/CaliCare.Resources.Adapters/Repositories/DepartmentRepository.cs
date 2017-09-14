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
   public class DepartmentRepository : IDepartmentRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "departments.json");

      public Department Find(string name)
         => FindAll()
            .Where(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase))
            .SingleOrDefault();

      public IReadOnlyList<Department> FindAll()
      {
         try { return JsonConvert.DeserializeObject<Department[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<Department>(); }
      }

      public void Store(Department[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));
   }
}
