using System;

using MediatR;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Domain;
using CaliCare.Infrastructure.Extensions;
using CaliCare.Conditions.Application.Commands;

namespace CaliCare.Conditions.Application.Queries.Handlers
{
   public class CreateConditionQueryHandler : IQueryHandler<CreateConditionQuery, PatientConditionDto>
   {
      private readonly IMediator _mediator;

      public CreateConditionQueryHandler(IMediator mediator)
      {
         _mediator = mediator;
      }

      public PatientConditionDto Handle(CreateConditionQuery message)
      {
         if (message.Condition == null)
            throw new ArgumentNullException($"{nameof(message.Condition)} cannot be undefined.");

         var createdCondition = ConditionConverter.ConvertToDto(PatientCondition.Create(
            message.Condition.Type,
            message.Condition.Classification,
            message.Condition.PatientId,
            message.Condition.TopogId));

         _mediator.SendSync(new StoreConditionCommand() { Condition = createdCondition });

         return createdCondition;
      }
   }
}
