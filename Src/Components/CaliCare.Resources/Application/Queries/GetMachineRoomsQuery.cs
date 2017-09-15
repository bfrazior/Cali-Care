using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Queries
{
   public class GetMachineRoomsQuery : IQuery<IReadOnlyList<RoomDto>>
   {
      public bool FilterAdvancedCapability { get; set; }
   }
}
