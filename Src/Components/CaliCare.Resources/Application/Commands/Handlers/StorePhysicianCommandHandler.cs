using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Commands.Handlers
{
   public class StorePhysicianCommandHandler : ICommandHandler<StorePhysicianCommand>
   {
      private readonly IPhysicianRepository _physicianRepository;

      public StorePhysicianCommandHandler(IPhysicianRepository physicianRepository)
      {
         _physicianRepository = physicianRepository;
      }

      public void Handle(StorePhysicianCommand message)
      {
         if (message.PhysicianDto == null)
            throw new ArgumentNullException($"{nameof(message.PhysicianDto)} cannot be undefined.");

         _physicianRepository.Store(ResourceConverter.ConvertToDomain(message.PhysicianDto));
      }
   }
}
