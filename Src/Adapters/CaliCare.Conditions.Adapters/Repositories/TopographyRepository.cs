using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Newtonsoft.Json;

using CaliCare.Conditions.Ports.Repositories;
using CaliCare.Conditions.Domain;
using CaliCare.Conditions.Common;
using CaliCare.Infrastructure.Utilities;

namespace CaliCare.Conditions.Adapters.Repositories
{
   public class TopographyRepository : ITopographyRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "topographies.json");

      public Topography Find(Guid id)
         => FindAll().Where(x => x.Id == id).SingleOrDefault();

      public IReadOnlyList<Topography> FindAll()
         => JsonConvert.DeserializeObject<Topography[]>(File.ReadAllText(_jsonPath)).ToList();

      public IReadOnlyList<Topography> FindAll(TopographyClassification classification)
         => FindAll().Where(x => x.Classification == classification).ToList();

      public void Store(Topography[] topographies)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(topographies));
   }
}
