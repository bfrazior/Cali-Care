using System;
using System.Collections.Generic;

using CaliCare.Conditions.Domain;
using CaliCare.Conditions.Common;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Ports.Repositories
{
   public interface IConditionRepository : IRepository<PatientCondition>
   {
      PatientCondition Find(Guid id);

      IReadOnlyList<PatientCondition> FindAll(ConditionClassification classification);

      void Store(PatientCondition condition);
   }
}
