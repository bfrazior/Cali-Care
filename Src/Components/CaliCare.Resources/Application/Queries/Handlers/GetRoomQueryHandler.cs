using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetRoomQueryHandler : IQueryHandler<GetRoomQuery, RoomDto>
   {
      private readonly IRoomRepository _roomRepository;

      public GetRoomQueryHandler(IRoomRepository roomRepository)
      {
         _roomRepository = roomRepository;
      }

      public RoomDto Handle(GetRoomQuery message)
      {
         if (message.Id == Guid.Empty)
            throw new ArgumentException($"{nameof(message.Id)} cannot be empty.");

         return ResourceConverter.ConvertToDto(_roomRepository.Find(message.Id));
      }
   }
}
