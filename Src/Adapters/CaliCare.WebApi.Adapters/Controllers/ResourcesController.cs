using System;
using System.Collections.Generic;
using System.Web.Http;

using MediatR;

using CaliCare.Resources.Application.Queries;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Extensions;

namespace CaliCare.WebApi.Adapters.Controllers
{
   [RoutePrefix("api/resources")]
   public class ResourcesController : ApiController
   {
      private readonly IMediator _mediator;

      public ResourcesController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [Route("departments")]
      public IEnumerable<DepartmentDto> GetDepartments()
      {
         return _mediator.SendSync(new GetDepartmentsQuery());
      }

      [Route("machines/{filterAdvanced:bool}")]
      public IEnumerable<MachineDto> GetMachines(bool filterAdvanced)
      {
         return _mediator.SendSync(new GetMachinesQuery() { FilterAdvancedMachines = filterAdvanced });
      }

      [Route("machines/room/{roomId:Guid}")]
      public MachineDto GetMachineInRoom(Guid roomId)
      {
         return _mediator.SendSync(new GetMachineByRoomIdQuery() { RoomId = roomId });
      }

      [Route("physicians/{id:Guid}")]
      public PhysicianDto GetPhysician(Guid id)
      {
         return _mediator.SendSync(new GetPhysicianQuery() { Id = id });
      }

      [Route("physicians")]
      public IEnumerable<PhysicianDto> GetPhysicians()
      {
         return _mediator.SendSync(new GetPhysiciansQuery());
      }


      [Route("rooms/{id:Guid}")]
      public RoomDto GetRoom(Guid id)
      {
         return _mediator.SendSync(new GetRoomQuery() { Id = id });
      }

      [Route("rooms/department/{departmentId:Guid}")]
      public IEnumerable<RoomDto> GetRooms(Guid departmentId)
      {
         return _mediator.SendSync(new GetRoomsQuery() { DepartmentId = departmentId });
      }
   }
}
