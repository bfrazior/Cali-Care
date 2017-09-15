using System.Collections.Generic;

using MediatR;

using CaliCare.Infrastructure.Extensions;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetMachineRoomsQueryHandler : IQueryHandler<GetMachineRoomsQuery, IReadOnlyList<RoomDto>>
   {
      private readonly IMachineRepository _machineRepository;
      private readonly IMediator _mediator;

      public GetMachineRoomsQueryHandler(IMediator mediator)
      {
         _mediator = mediator;
      }

      public IReadOnlyList<RoomDto> Handle(GetMachineRoomsQuery message)
      {
         var machines = _mediator.SendSync(new GetMachinesQuery() { FilterAdvancedMachines = message.FilterAdvancedCapability });

         var machineRooms = new List<RoomDto>();
         foreach (var machine in machines)
            machineRooms.Add(_mediator.SendSync(new GetRoomQuery() { Id = machine.RoomId }));

         return machineRooms;
      }
   }
}
