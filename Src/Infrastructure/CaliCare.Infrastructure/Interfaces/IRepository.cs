using System.Collections.Generic;

namespace CaliCare.Infrastructure.Interfaces
{
   public interface IRepository<T> where T : IAggregateRoot
   {
      IReadOnlyList<T> FindAll();

      void Store(T[] aggregates);
   }
}
