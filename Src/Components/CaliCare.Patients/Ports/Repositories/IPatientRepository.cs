using System;

using CaliCare.Patients.Domain;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Patients.Ports.Repositories
{
   public interface IPatientRepository : IRepository<Patient>
   {
      Patient Find(Guid id);

      void Store(Patient patient);
   }
}
