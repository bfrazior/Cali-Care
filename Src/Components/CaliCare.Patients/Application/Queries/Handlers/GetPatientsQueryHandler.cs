using System.Linq;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Patients.Ports.DataTransferObjects;
using CaliCare.Patients.Ports.Repositories;

namespace CaliCare.Patients.Application.Queries.Handlers
{
   public class GetPatientsQueryHandler : IQueryHandler<GetPatientsQuery, IReadOnlyList<PatientDto>>
   {
      private readonly IPatientRepository _patientRepository;

      public GetPatientsQueryHandler(IPatientRepository patientRepository)
      {
         _patientRepository = patientRepository;
      }

      public IReadOnlyList<PatientDto> Handle(GetPatientsQuery message)
         => _patientRepository.FindAll().Select(x => PatientConverter.ConvertToDto(x)).ToList();
   }
}
