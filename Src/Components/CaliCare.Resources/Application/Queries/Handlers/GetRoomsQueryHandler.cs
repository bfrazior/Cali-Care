using System;
using System.Collections.Generic;
using System.Linq;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetRoomsQueryHandler : IQueryHandler<GetRoomsQuery, IReadOnlyList<RoomDto>>
   {
      private readonly IRoomRepository _roomRepository;

      public GetRoomsQueryHandler(IRoomRepository roomRepository)
      {
         _roomRepository = roomRepository;
      }

      public IReadOnlyList<RoomDto> Handle(GetRoomsQuery message)
      {
         if (message.DepartmentId == Guid.Empty)
            throw new ArgumentException($"{nameof(message.DepartmentId)} cannot be empty.");

         return _roomRepository.FindAll(message.DepartmentId).Select(x => ResourceConverter.ConvertToDto(x)).ToList();
      }
   }
}
