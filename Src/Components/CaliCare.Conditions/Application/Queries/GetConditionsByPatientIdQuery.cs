using System;
using System.Collections.Generic;

using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Conditions.Application.Queries
{
   public class GetConditionsByPatientIdQuery : IQuery<IReadOnlyList<PatientConditionDto>>
   {
      public Guid PatientId { get; set; }
   }
}
