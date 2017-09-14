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
   public class ScheduleRepository : IScheduleRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "scheduleDays.json");

      public ScheduleDay Find(DateTime Date)
         => FindAll().Where(x => x.Date.Date == Date.Date).SingleOrDefault();

      public IReadOnlyList<ScheduleDay> FindAll()
      {
         try { return JsonConvert.DeserializeObject<ScheduleDay[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<ScheduleDay>(); }
      }

      public void Store(ScheduleDay[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));

      public void Store(ScheduleDay scheduleDay)
      {
         var scheduleDays = FindAll().ToList();
         scheduleDays.Add(scheduleDay);
         Store(scheduleDays.ToArray());
      }
   }
}
