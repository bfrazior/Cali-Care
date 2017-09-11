using System;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Application.Queries
{
   public class GetConditionQuery : IQuery<PatientConditionDto>
   {
      public Guid Id { get; set; }
   }
}
