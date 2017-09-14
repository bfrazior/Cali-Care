using System;
using System.Collections.Generic;

using CaliCare.Resources.Domain;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Resources.Ports.Repositories
{
   public interface IRoomRepository : IRepository<Room>
   {
      Room Find(Guid id);

      IReadOnlyList<Room> FindAll(Guid departmentId);
   }
}
