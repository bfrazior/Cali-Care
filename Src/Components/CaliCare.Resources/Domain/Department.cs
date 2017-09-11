using System;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Resources.Domain
{
   public class Department : IAggregateRoot
   {
      public Guid Id { get; }
      public string Name { get; }

      public Department(Guid id, string name)
      {
         Id = id;
         Name = name;
      }

      public static Department Create(string name)
         => new Department(Guid.NewGuid(), name);
   }
}
