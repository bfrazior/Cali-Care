using System;

using MediatR;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Common;
using CaliCare.Resources.Ports.Repositories;
using CaliCare.Infrastructure.Extensions;
using CaliCare.Resources.Application.Queries;
using System.Linq;

namespace CaliCare.Resources.Application.Commands.Handlers
{
   public class SeedMachineCommandHandler : ICommandHandler<SeedMachinesCommand>
   {
      private readonly IMachineRepository _machineRepository;
      private readonly IMediator _mediator;

      public SeedMachineCommandHandler(
         IMachineRepository machineRepository,
         IMediator mediator)
      {
         _machineRepository = machineRepository;
         _mediator = mediator;
      }

      public void Handle(SeedMachinesCommand message)
      {
         var department = _mediator.SendSync(new GetDepartmentByNameQuery() { Name = "Los Gatos Radiation Oncology" });
         if (department == null)
            throw new InvalidOperationException($"{nameof(GetDepartmentByNameQuery)} failed to return a result.");

         var rooms = _mediator.SendSync(new GetRoomsQuery() { DepartmentId = department.Id });
         if (rooms.Count == 0)
            throw new InvalidOperationException($"{nameof(GetRoomsQuery)} failed to return a result.");

         var room1 = rooms.Where(x => string.Equals(x.Name, "One", StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
         var room2 = rooms.Where(x => string.Equals(x.Name, "Two", StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
         var room3 = rooms.Where(x => string.Equals(x.Name, "Three", StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
         if (room1 == null || room2 == null || room3 == null)
            throw new InvalidOperationException($"{nameof(GetRoomsQuery)} failed to return machine rooms.");


         var simpleCharacterization = new MachineCharacterization(MachineCapability.Simple);
         var advancedCharacterization = new MachineCharacterization(MachineCapability.Advanced);

         var machines = new Machine[]
         {
            Machine.Create("Elekta", room1.Id, advancedCharacterization),
            Machine.Create("Varian", room2.Id, advancedCharacterization),
            Machine.Create("MM50", room3.Id, simpleCharacterization)
         };

         _machineRepository.Store(machines);
      }
   }
}
