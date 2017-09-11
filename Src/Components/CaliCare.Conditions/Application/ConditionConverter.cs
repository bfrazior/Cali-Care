using CaliCare.Conditions.Domain;
using CaliCare.Conditions.Ports.DataTransferObjects;

namespace CaliCare.Conditions.Application
{
   internal static class ConditionConverter
   {
      public static PatientCondition ConvertToDomain(PatientConditionDto conditionDto)
         => conditionDto == null ? null : new PatientCondition(
            conditionDto.Id,
            conditionDto.Type,
            conditionDto.Classification,
            conditionDto.PatientId,
            conditionDto.TopogId);

      public static PatientConditionDto ConvertToDto(PatientCondition condition)
         => condition == null ? null : new PatientConditionDto()
         {
            Classification = condition.Classification,
            Id = condition.Id,
            PatientId = condition.PatientId,
            TopogId = condition.TopogId,
            Type = condition.Type
         };

      public static TopographyDto ConvertToDto(Topography topography)
         => topography == null ? null : new TopographyDto()
         {
            Classification = topography.Classification,
            Code = topography.Code,
            Id = topography.Id
         };

   }
}
