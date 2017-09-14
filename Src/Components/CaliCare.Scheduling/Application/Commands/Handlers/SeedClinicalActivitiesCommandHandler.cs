using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.Repositories;
using CaliCare.Schedule.Domain;

namespace CaliCare.Schedule.Application.Commands.Handlers
{
   public class SeedClinicalActivitiesCommandHandler : ICommandHandler<SeedClinicalActivitiesCommand>
   {
      private readonly IClinicalActivityRepository _clinicalActivityRepository;

      public SeedClinicalActivitiesCommandHandler(IClinicalActivityRepository clinicalActivityRepository)
      {
         _clinicalActivityRepository = clinicalActivityRepository;
      }

      public void Handle(SeedClinicalActivitiesCommand message)
      {
         if (_clinicalActivityRepository.FindAll().Count > 0)
            return;

         var clinicalActvities = new ClinicalActivity[]
         {
            ClinicalActivity.Create("con", "54321", "New Patient Consult")
         };

         _clinicalActivityRepository.Store(clinicalActvities);
      }
   }
}
