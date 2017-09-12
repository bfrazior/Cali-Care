using System;

using CaliCare.Resources.Domain;
using CaliCare.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace CaliCare.Resources.Ports.Repositories
{
   public interface IRoomRepository : IRepository<Room>
   {
      IReadOnlyList<Room> FindAll(Guid departmentId);
   }
}
