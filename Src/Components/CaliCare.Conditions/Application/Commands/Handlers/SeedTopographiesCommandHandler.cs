using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Ports.Repositories;
using CaliCare.Conditions.Domain;
using CaliCare.Conditions.Common;

namespace CaliCare.Conditions.Application.Commands.Handlers
{
   public class SeedTopographiesCommandHandler : ICommandHandler<SeedTopographiesCommand>
   {
      private readonly ITopographyRepository _topographyRepository;

      public SeedTopographiesCommandHandler(ITopographyRepository topographyRepository)
      {
         _topographyRepository = topographyRepository;
      }

      public void Handle(SeedTopographiesCommand message)
      {
         if (_topographyRepository.FindAll().Count > 0)
            return;

         var topographies = new Topography[]
         {
            Topography.Create("Head & Neck", TopographyClassification.Custom),
            Topography.Create("Breast", TopographyClassification.Custom)
         };

         _topographyRepository.Store(topographies);
      }
   }
}
