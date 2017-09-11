using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Queries
{
   public class GetMachinesQuery : IQuery<IReadOnlyList<MachineDto>>
   {
      public bool FilterAdvancedMachines { get; set; }
   }
}
