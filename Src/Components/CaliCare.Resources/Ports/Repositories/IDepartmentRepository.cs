using CaliCare.Resources.Domain;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Resources.Ports.Repositories
{
   public interface IDepartmentRepository : IRepository<Department>
   {
      Department Find(string name);
   }
}
