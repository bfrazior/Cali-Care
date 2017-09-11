using System;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Application.Queries.Handlers
{
   public class GetConditionQueryHandler : IQueryHandler<GetConditionQuery, PatientConditionDto>
   {
      public GetConditionQueryHandler()
      {
      }

      public PatientConditionDto Handle(GetConditionQuery message)
      {
         throw new NotImplementedException();
      }
   }
}
