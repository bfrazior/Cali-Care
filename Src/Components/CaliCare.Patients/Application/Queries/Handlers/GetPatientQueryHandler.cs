using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Patients.Ports.DataTransferObjects;
using CaliCare.Patients.Ports.Repositories;

namespace CaliCare.Patients.Application.Queries.Handlers
{
   public class GetPatientQueryHandler : IQueryHandler<GetPatientQuery, PatientDto>
   {
      private readonly IPatientRepository _patientRepository;

      public GetPatientQueryHandler(IPatientRepository patientRepository)
      {
         _patientRepository = patientRepository;
      }

      public PatientDto Handle(GetPatientQuery message)
      {
         if (message.Id == Guid.Empty)
            throw new ArgumentException($"{nameof(message.Id)} cannot be empty.");

         return PatientConverter.ConvertToDto(_patientRepository.Find(message.Id));
      }
   }
}
