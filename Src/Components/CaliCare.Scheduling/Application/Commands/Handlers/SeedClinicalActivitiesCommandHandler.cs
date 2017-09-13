using CaliCare.Infrastructure.Interfaces;
using CaliCare.Scheduling.Ports.Repositories;
using CaliCare.Scheduling.Domain;

namespace CaliCare.Scheduling.Application.Commands.Handlers
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
         var clinicalActvities = new ClinicalActivity[]
         {
            ClinicalActivity.Create("con", "54321", "New Patient Consult")
         };

         _clinicalActivityRepository.Store(clinicalActvities);
      }
   }
}
