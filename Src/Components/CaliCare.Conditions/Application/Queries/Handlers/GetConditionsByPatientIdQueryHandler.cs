using System;
using System.Linq;
using System.Collections.Generic;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Ports.Repositories;

namespace CaliCare.Conditions.Application.Queries.Handlers
{
   public class GetConditionsByPatientIdQueryHandler : IQueryHandler<GetConditionsByPatientIdQuery, IReadOnlyList<PatientConditionDto>>
   {
      private readonly IConditionRepository _conditionRepository;

      public GetConditionsByPatientIdQueryHandler(IConditionRepository conditionRepository)
      {
         _conditionRepository = conditionRepository;
      }

      public IReadOnlyList<PatientConditionDto> Handle(GetConditionsByPatientIdQuery message)
      {
         if (message.PatientId == Guid.Empty)
            throw new ArgumentException($"{nameof(message.PatientId)} cannot be undefined.");

         return _conditionRepository.FindAllByPatientId(message.PatientId)
            .Select(x => ConditionConverter.ConvertToDto(x))
            .ToList();
      }
   }
}
