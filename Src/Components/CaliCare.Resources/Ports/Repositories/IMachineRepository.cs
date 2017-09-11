using System.Collections.Generic;

using CaliCare.Resources.Domain;
using CaliCare.Resources.Common;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Resources.Ports.Repositories
{
   public interface IMachineRepository : IRepository<Machine>
   {
      IReadOnlyList<Machine> FindAll(MachineCapability capability);
   }
}
