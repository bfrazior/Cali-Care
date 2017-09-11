using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Application.Commands
{
   public class StoreConditionCommand : ICommand
   {
      public PatientConditionDto Condition { get; set; }
   }
}
