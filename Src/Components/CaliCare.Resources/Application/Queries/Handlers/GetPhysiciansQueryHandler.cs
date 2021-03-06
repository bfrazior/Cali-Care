﻿using System.Linq;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetPhysiciansQueryHandler : IQueryHandler<GetPhysiciansQuery, IReadOnlyList<PhysicianDto>>
   {
      private readonly IPhysicianRepository _physicianRepository;

      public GetPhysiciansQueryHandler(IPhysicianRepository physicianRepository)
      {
         _physicianRepository = physicianRepository;
      }

      public IReadOnlyList<PhysicianDto> Handle(GetPhysiciansQuery message)
      {
         var physicians = _physicianRepository.FindAll().Select(x => ResourceConverter.ConvertToDto(x)).ToList();

         if (message.FilterRoles == null)
            return physicians;

         foreach(var filter in message.FilterRoles)
            physicians = physicians.Where(x => x.Roles.Contains(filter)).ToList();

         return physicians;
      }
   }
}
