using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetMachineByRoomIdQueryHandler : IQueryHandler<GetMachineByRoomIdQuery, MachineDto>
   {
      private readonly IMachineRepository _machineRepository;

      public GetMachineByRoomIdQueryHandler(IMachineRepository machineRepository)
      {
         _machineRepository = machineRepository;
      }

      public MachineDto Handle(GetMachineByRoomIdQuery message)
      {
         if (message.RoomId == Guid.Empty)
            throw new ArgumentException($"{nameof(message.RoomId)} cannot be empty.");

         return ResourceConverter.ConvertToDto(_machineRepository.FindByRoomId(message.RoomId));
      }
   }
}
