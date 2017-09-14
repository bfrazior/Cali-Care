using System;
using System.Collections.Generic;

using CaliCare.Conditions.Domain;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Ports.Repositories
{
   public interface IConditionRepository : IRepository<PatientCondition>
   {
      PatientCondition Find(Guid id);

      IReadOnlyList<PatientCondition> FindAllByPatientId(Guid patientId);

      void Store(PatientCondition condition);
   }
}
