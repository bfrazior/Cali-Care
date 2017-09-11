using CaliCare.Resources.Common;

namespace CaliCare.Resources.Domain
{
   public class MachineCharacterization
   {
      public MachineCapability Capability { get; }

      public MachineCharacterization(MachineCapability capability)
      {
         Capability = capability;
      }
   }
}
