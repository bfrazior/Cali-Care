using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Queries
{
   public class GetMachineByRoomIdQuery : IQuery<MachineDto>
   {
      public Guid RoomId { get; set; }
   }
}
