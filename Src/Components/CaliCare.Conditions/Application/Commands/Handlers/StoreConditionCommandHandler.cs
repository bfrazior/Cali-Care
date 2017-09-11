using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Ports.Repositories;

namespace CaliCare.Conditions.Application.Commands.Handlers
{
   public class StoreConditionCommandHandler : ICommandHandler<StoreConditionCommand>
   {
      private readonly IConditionRepository _conditionRepository;

      public StoreConditionCommandHandler(IConditionRepository conditionRepository)
      {
         _conditionRepository = conditionRepository;
      }

      public void Handle(StoreConditionCommand message)
      {
         if (message.Condition == null)
            throw new ArgumentNullException($"{nameof(message.Condition)} cannot be undefined.");

         _conditionRepository.Store(ConditionConverter.ConvertToDomain(message.Condition));
      }
   }
}
