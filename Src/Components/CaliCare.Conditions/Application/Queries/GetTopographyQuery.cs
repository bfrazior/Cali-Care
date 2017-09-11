using System;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Application.Queries
{
   public class GetTopographyQuery : IQuery<TopographyDto>
   {
      public Guid Id { get; set; }
   }
}
