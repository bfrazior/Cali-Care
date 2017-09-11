using System;

using MediatR;

using CaliCare.Infrastructure.Extensions;
using CaliCare.Infrastructure.Interfaces;
using CaliCare.Patients.Application.Commands;
using CaliCare.Patients.Domain;
using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.Patients.Application.Queries.Handlers
{
   public class CreatePatientQueryHandler : IQueryHandler<CreatePatientQuery, PatientDto>
   {
      private readonly IMediator _mediator;

      public CreatePatientQueryHandler(IMediator mediator)
      {
         _mediator = mediator;
      }

      public PatientDto Handle(CreatePatientQuery message)
      {
         if (message.PatientName == null)
            throw new ArgumentNullException($"{nameof(message.PatientName)} cannot be undefined.");

         var createdPatient = PatientConverter.ConvertToDto(Patient.Create(PatientConverter.ConvertToDomain(message.PatientName)));
         _mediator.SendSync(new StorePatientCommand() { Patient = createdPatient });

         return createdPatient;
      }
   }
}
