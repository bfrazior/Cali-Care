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
   public class ScheduleSlotRepository : IScheduleSlotRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "scheduleSlots.json");

      public ScheduleSlot Find(Guid id)
         => FindAll().Where(x => x.Id == id).SingleOrDefault();

      public IReadOnlyList<ScheduleSlot> FindAll()
      {
         try { return JsonConvert.DeserializeObject<ScheduleSlot[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<ScheduleSlot>(); }
      }

      public IReadOnlyList<ScheduleSlot> FindAll(DateTime date)
         => FindAll(date).Where(x => x.Date.Date == date.Date).ToList();

      public void Store(ScheduleSlot[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));

      public void Store(ScheduleSlot scheduleSlot)
      {
         var slots = FindAll().ToList();
         var foundSlot = slots.Where(x => x.Id == scheduleSlot.Id).SingleOrDefault();

         if (foundSlot != null)
            foundSlot = scheduleSlot;
         else
            slots.Add(scheduleSlot);

         Store(slots.ToArray());
         return;
      }
   }
}
