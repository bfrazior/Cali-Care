using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Domain;

namespace CaliCare.Resources.Ports.Repositories
{
   public interface IPhysicianRepository : IRepository<Physician>
   {
      void Store(Physician physician);
   }
}
