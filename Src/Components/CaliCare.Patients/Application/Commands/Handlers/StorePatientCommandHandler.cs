using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Patients.Ports.Repositories;

namespace CaliCare.Patients.Application.Commands.Handlers
{
   public class StorePatientCommandHandler : ICommandHandler<StorePatientCommand>
   {
      private readonly IPatientRepository _patientRepository;

      public StorePatientCommandHandler(IPatientRepository patientRepository)
      {
         _patientRepository = patientRepository;
      }

      public void Handle(StorePatientCommand message)
      {
         if (message.Patient == null)
            throw new ArgumentNullException($"Cannot store patient. {nameof(message.Patient)} is undefined.");

         _patientRepository.Store(PatientConverter.ConvertToDomain(message.Patient));
      }
   }
}
