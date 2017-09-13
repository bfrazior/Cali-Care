using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Domain;

namespace CaliCare.Schedule.Ports.Repositories
{
   public interface IClinicalActivityRepository : IRepository<ClinicalActivity>
   {
      ClinicalActivity Find(string code);
   }
}
