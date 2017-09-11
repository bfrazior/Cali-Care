using CaliCare.Patients.Domain;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Patients.Ports.Repositories
{
   public interface IPatientRepository : IRepository<Patient>
   {
      void Store(Patient patient);
   }
}
