using System;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Queries
{
   public class GetRoomsQuery : IQuery<IReadOnlyList<RoomDto>>
   {
      public Guid DepartmentId { get; set; }
   }
}
