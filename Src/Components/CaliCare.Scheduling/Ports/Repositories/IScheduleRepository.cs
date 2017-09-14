using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Domain;

namespace CaliCare.Schedule.Ports.Repositories
{
   public interface IScheduleRepository : IRepository<ScheduleDay>
   {
      ScheduleDay Find(DateTime Date);

      void Store(ScheduleDay scheduleDay);
   }
}
