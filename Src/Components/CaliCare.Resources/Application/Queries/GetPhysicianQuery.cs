using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Queries
{
   public class GetPhysicianQuery : IQuery<PhysicianDto>
   {
      public Guid Id { get; set; }
   }
}
