using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Queries
{
   public class GetPhysicianQueryHandler : IQueryHandler<GetPhysicianQuery, PhysicianDto>
   {
      private readonly IPhysicianRepository _physicianRepository;

      public GetPhysicianQueryHandler(IPhysicianRepository physicianRepository)
      {
         _physicianRepository = physicianRepository;
      }

      public PhysicianDto Handle(GetPhysicianQuery message)
      {
         if (message.Id == Guid.Empty)
            throw new ArgumentException($"{message.Id} cannot be empty.");

         return ResourceConverter.ConvertToDto(_physicianRepository.Find(message.Id));
      }
   }
}
