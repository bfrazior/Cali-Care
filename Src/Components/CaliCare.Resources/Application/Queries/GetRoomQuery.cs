using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Queries
{
   public class GetRoomQuery : IQuery<RoomDto>
   {
      public Guid Id { get; set; }
   }
}
