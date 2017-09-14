using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Domain;
using System.Collections.Generic;

namespace CaliCare.Schedule.Ports.Repositories
{
   public interface IScheduleSlotRepository : IRepository<ScheduleSlot>
   {
      ScheduleSlot Find(Guid id);

      IReadOnlyList<ScheduleSlot> FindAll(DateTime date);

      void Store(ScheduleSlot scheduleSlot);
   }
}
