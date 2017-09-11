using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Common;

namespace CaliCare.Resources.Domain
{
   public class Physician : IAggregateRoot
   {
      public Guid Id { get; }
      public PhysicianName Name { get; }
      public PhysicianRole[] Roles { get; }
   }
}
