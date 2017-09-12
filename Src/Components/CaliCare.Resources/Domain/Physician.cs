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

      public Physician(Guid id, PhysicianName name, PhysicianRole[] roles)
      {
         Id = id;
         Name = name;
         Roles = roles;
      }

      public static Physician Create(PhysicianName name, PhysicianRole[] roles)
         => new Physician(Guid.NewGuid(), name, roles);
   }
}
