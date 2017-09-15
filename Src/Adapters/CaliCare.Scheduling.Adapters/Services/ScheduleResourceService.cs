using System;
using System.Linq;

using MediatR;

using CaliCare.Schedule.Ports.Services;
using CaliCare.Infrastructure.Extensions;
using CaliCare.Resources.Application.Queries;
using CaliCare.Resources.Common;

namespace CaliCare.Schedule.Adapters.Services
{
   public class ScheduleResourceService : IScheduleResourceService
   {
      private readonly IMediator _mediator;

      public ScheduleResourceService(IMediator mediator)
      {
         _mediator = mediator;
      }

      public Guid[] GetMachineRooms(bool filterAdvancedCapability)
         => _mediator.SendSync(new GetMachineRoomsQuery() { FilterAdvancedCapability = filterAdvancedCapability })
            .Select(x => x.Id)
            .ToArray();

      public Guid[] GetNonMachineRooms(Guid departmentId)
         => _mediator.SendSync(new GetNonMachineRoomsQuery() { DepartmentId = departmentId })
            .Select(x => x.Id)
            .ToArray();

      public Guid[] GetPhysiciansByRole(string role)
      {
         PhysicianRole physicianRole;
         if (!Enum.TryParse(role, out physicianRole))
            return null;

         return _mediator.SendSync(new GetPhysiciansQuery() { FilterRoles = new PhysicianRole[] { physicianRole } })
            .Select(x => x.Id)
            .ToArray();
      }
   }
}
