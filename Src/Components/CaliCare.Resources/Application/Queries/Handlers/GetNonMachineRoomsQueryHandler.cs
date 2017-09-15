using System.Collections.Generic;
using System.Linq;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetNonMachineRoomsQueryHandler : IQueryHandler<GetNonMachineRoomsQuery, IReadOnlyList<RoomDto>>
   {
      private readonly IMachineRepository _machineRepository;
      private readonly IRoomRepository _roomRepository;

      public GetNonMachineRoomsQueryHandler(
         IRoomRepository roomRepository,
         IMachineRepository machineRepository)
      {
         _roomRepository = roomRepository;
         _machineRepository = machineRepository;
      }

      public IReadOnlyList<RoomDto> Handle(GetNonMachineRoomsQuery message)
      {
         var rooms = _roomRepository.FindAll(message.DepartmentId);

         var nonMachineRooms = new List<Room>();
         foreach(var room in rooms)
         {
            if (_machineRepository.FindByRoomId(room.Id) == null)
               nonMachineRooms.Add(room);          
         }

         return nonMachineRooms.Select(x => ResourceConverter.ConvertToDto(x)).ToList();
      }
   }
}
