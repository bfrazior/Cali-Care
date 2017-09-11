using System.Collections.Generic;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Common;

namespace CaliCare.Conditions.Application.Queries
{
   public class GetConditionsQuery : IQuery<IReadOnlyList<PatientConditionDto>>
   {
      public ConditionClassification[] ClassificationFilters { get; set; }
   }
}
