using System.Linq;
using System.Collections.Generic;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Ports.Repositories;

namespace CaliCare.Conditions.Application.Queries.Handlers
{
   public class GetConditionsQueryHandler : IQueryHandler<GetConditionsQuery, IReadOnlyList<PatientConditionDto>>
   {
      private readonly IConditionRepository _conditionRepository;

      public GetConditionsQueryHandler(IConditionRepository conditionRepository)
      {
         _conditionRepository = conditionRepository;
      }

      public IReadOnlyList<PatientConditionDto> Handle(GetConditionsQuery message)
         => _conditionRepository.FindAll().Select(x => ConditionConverter.ConvertToDto(x)).ToList();
   }
}
