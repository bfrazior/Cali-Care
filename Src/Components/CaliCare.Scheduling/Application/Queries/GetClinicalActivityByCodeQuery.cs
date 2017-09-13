using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Queries
{
   public class GetClinicalActivityByCodeQuery : IQuery<ClinicalActivityDto>
   {
      public string Code { get; set; }
   }
}
