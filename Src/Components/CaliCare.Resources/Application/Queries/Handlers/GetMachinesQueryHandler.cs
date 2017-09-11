using System.Linq;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;
using CaliCare.Resources.Common;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetMachinesQueryHandler : IQueryHandler<GetMachinesQuery, IReadOnlyList<MachineDto>>
   {
      private readonly IMachineRepository _machineRepository;

      public GetMachinesQueryHandler(IMachineRepository machineRepository)
      {
         _machineRepository = machineRepository;
      }

      public IReadOnlyList<MachineDto> Handle(GetMachinesQuery message)
         => message.FilterAdvancedMachines
         ? _machineRepository.FindAll(MachineCapability.Advanced)
            .Select(x => ResourceConverter.ConvertToDto(x))
            .ToList()
         : _machineRepository.FindAll()
            .Select(x => ResourceConverter.ConvertToDto(x))
            .ToList();
   }
}
