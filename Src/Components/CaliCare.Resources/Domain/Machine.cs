using System;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Resources.Domain
{
   public class Machine : IAggregateRoot
   {
      public Guid Id { get; }
      public MachineCharacterization Characterization { get; }
      public string Name { get; }
      public Guid RoomId { get; }

      public Machine(Guid id, string name, Guid roomId, MachineCharacterization characterization)
      {
         Id = id;
         Name = name;
         RoomId = roomId;
         Characterization = characterization;
      }

      public static Machine Create(string name, Guid roomId, MachineCharacterization characterization)
         => new Machine(Guid.NewGuid(), name, roomId, characterization);
   }
}
