using System;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Conditions.Ports.Repositories;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Application.Queries.Handlers
{
   public class GetTopographyQueryHandler : IQueryHandler<GetTopographyQuery, TopographyDto>
   {
      private readonly ITopographyRepository _topogRepository;

      public GetTopographyQueryHandler(ITopographyRepository topogRepository)
      {
         _topogRepository = topogRepository;
      }

      public TopographyDto Handle(GetTopographyQuery message)
      {
         if (message.Id == Guid.Empty)
            throw new ArgumentException($"{nameof(message.Id)} cannot be empty.");

         return ConditionConverter.ConvertToDto(_topogRepository.Find(message.Id));
      }
   }
}
