using System;
using System.Collections.Generic;

using CaliCare.Conditions.Domain;
using CaliCare.Conditions.Common;

namespace CaliCare.Conditions.Ports.Repositories
{
   public interface ITopographyRepository
   {
      Topography Find(Guid id);

      IReadOnlyList<Topography> FindAll();

      IReadOnlyList<Topography> FindAll(TopographyClassification classification);

      void Store(Topography[] topographies);
   }
}
