using System.Linq;
using System.Collections.Generic;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Ports.Repositories;

namespace CaliCare.Conditions.Application.Queries.Handlers
{
   public class GetTopographiesQueryHandler : IQueryHandler<GetTopographiesQuery, IReadOnlyList<TopographyDto>>
   {
      private readonly ITopographyRepository _topogRepository;

      public GetTopographiesQueryHandler(ITopographyRepository topogRepository)
      {
         _topogRepository = topogRepository;
      }

      public IReadOnlyList<TopographyDto> Handle(GetTopographiesQuery message)
         => _topogRepository.FindAll().Select(x => ConditionConverter.ConvertToDto(x)).ToList();
   }
}
