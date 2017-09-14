using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Common;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Commands.Handlers
{
   public class SeedPhysiciansCommandHandler : ICommandHandler<SeedPhysiciansCommand>
   {
      private readonly IPhysicianRepository _physicianRepository;

      public SeedPhysiciansCommandHandler(IPhysicianRepository physicianRepository)
      {
         _physicianRepository = physicianRepository;
      }

      public void Handle(SeedPhysiciansCommand message)
      {
         if (_physicianRepository.FindAll().Count > 0)
            return;

         var physicians = new Physician[]
         {
            Physician.Create(new PhysicianName("John", "A", "Doe", "john"), new PhysicianRole[] { PhysicianRole.Oncologist }),
            Physician.Create(new PhysicianName("Anna", "B", "Smith", "anna"), new PhysicianRole[] { PhysicianRole.GeneralPractitioner }),
            Physician.Create(new PhysicianName("Peter", "C", "Davis", "pete"), new PhysicianRole[] { PhysicianRole.Oncologist, PhysicianRole.GeneralPractitioner }),
         };

         _physicianRepository.Store(physicians);
      }
   }
}
