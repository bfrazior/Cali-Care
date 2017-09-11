using System;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Resources.Domain
{
   public class Room : IAggregateRoot
   {
      public Guid Id { get; }
      public Guid DepartmentId { get; }
      public string Name { get; }

      public Room(Guid id, string name, Guid departmentId)
      {
         Id = id;
         Name = name;
         DepartmentId = departmentId;
      }

      public static Room Create(string name, Guid departmentId)
         => new Room(Guid.NewGuid(), name, departmentId);
   }
}
