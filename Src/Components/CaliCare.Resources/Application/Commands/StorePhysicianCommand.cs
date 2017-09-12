using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Commands
{
   public class StorePhysicianCommand : ICommand
   {
      public PhysicianDto PhysicianDto { get; set; }
   }
}
