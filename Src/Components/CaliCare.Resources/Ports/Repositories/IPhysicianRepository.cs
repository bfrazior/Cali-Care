using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Domain;

namespace CaliCare.Resources.Ports.Repositories
{
   public interface IPhysicianRepository : IRepository<Physician>
   {
      Physician Find(Guid id);

      void Store(Physician physician);
   }
}
