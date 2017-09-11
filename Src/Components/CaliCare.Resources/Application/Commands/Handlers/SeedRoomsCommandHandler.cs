﻿using MediatR;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Ports.Repositories;
using CaliCare.Infrastructure.Extensions;
using CaliCare.Resources.Application.Queries;

namespace CaliCare.Resources.Application.Commands.Handlers
{
   public class SeedRoomsCommandHandler : ICommandHandler<SeedRoomsCommand>
   {
      private readonly IMediator _mediator;
      private readonly IRoomRepository _roomRepository;

      public SeedRoomsCommandHandler(
         IRoomRepository roomRepository,
         IMediator mediator)
      {
         _roomRepository = roomRepository;
         _mediator = mediator;
      }

      public void Handle(SeedRoomsCommand message)
      {
         var radDept = _mediator.SendSync(new GetDepartmentByNameQuery() { Name = "Rad" });
         if (radDept == null)
            return;

         var departmentId = radDept.Id;
         var rooms = new Room[]
         {
            Room.Create("One", departmentId),
            Room.Create("Two", departmentId),
            Room.Create("Three", departmentId),
            Room.Create("Four", departmentId),
            Room.Create("Five", departmentId)
         };

         _roomRepository.Store(rooms);
      }
   }
}
