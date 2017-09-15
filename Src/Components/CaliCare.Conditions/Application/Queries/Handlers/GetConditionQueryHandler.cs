using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Ports.Repositories;

namespace CaliCare.Conditions.Application.Queries.Handlers
{
   public class GetConditionQueryHandler : IQueryHandler<GetConditionQuery, PatientConditionDto>
   {
      private readonly IConditionRepository _conditionRepository;

      public GetConditionQueryHandler(IConditionRepository conditionRepository)
      {
         _conditionRepository = conditionRepository;
      }

      public PatientConditionDto Handle(GetConditionQuery message)
      {
         return ConditionConverter.ConvertToDto(_conditionRepository.Find(message.Id));
      }
   }
}
