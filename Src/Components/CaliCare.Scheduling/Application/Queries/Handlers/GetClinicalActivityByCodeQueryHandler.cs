using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Schedule.Ports.Repositories;

namespace CaliCare.Schedule.Application.Queries.Handlers
{
   public class GetClinicalActivityByCodeQueryHandler : IQueryHandler<GetClinicalActivityByCodeQuery, ClinicalActivityDto>
   {
      private readonly IClinicalActivityRepository _clinicalActivityRepository;

      public GetClinicalActivityByCodeQueryHandler(IClinicalActivityRepository clinicalActivityRepository)
      {
         _clinicalActivityRepository = clinicalActivityRepository;
      }

      public ClinicalActivityDto Handle(GetClinicalActivityByCodeQuery message)
      {
         if (string.IsNullOrEmpty(message.Code))
            throw new ArgumentException($"{nameof(message.Code)} cannot be empty or undefined.");

         return ScheduleConverter.ConvertToDto(_clinicalActivityRepository.Find(message.Code));
      }
   }
}
