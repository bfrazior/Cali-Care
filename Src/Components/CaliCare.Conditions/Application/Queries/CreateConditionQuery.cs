using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Application.Queries
{
   public class CreateConditionQuery : IQuery<PatientConditionDto>
   {
      public PatientConditionDto Condition { get; set; }
   }
}
