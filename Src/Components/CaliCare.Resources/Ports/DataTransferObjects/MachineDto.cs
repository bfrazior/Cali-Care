using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliCare.Resources.Ports.DataTransferObjects
{
   public class MachineDto
   {
      public Guid Id { get; set; }
      public MachineCharacterizationDto Characterization { get; set; }
      public string Name { get; set; }
      public Guid RoomId { get; set; }
   }
}
