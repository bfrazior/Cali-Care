using CaliCare.Scheduling.Domain;
using CaliCare.Scheduling.Ports.DataTransferObjects;

namespace CaliCare.Scheduling.Application
{
   internal static class SchedulingConverter
   {
      public static ClinicalActivityDto ConvertToDto(ClinicalActivity activity)
         => activity == null ? null : new ClinicalActivityDto()
         {
            Code = activity.Code,
            Id = activity.Id,
            Name = activity.Name
         };
   }
}
