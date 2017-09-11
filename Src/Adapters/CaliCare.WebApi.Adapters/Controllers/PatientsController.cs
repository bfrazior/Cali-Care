using System.Collections.Generic;
using System.Web.Http;

using MediatR;

using CaliCare.Infrastructure.Extensions;
using CaliCare.Patients.Application.Queries;
using CaliCare.Patients.Ports.DataTransferObjects;

namespace CaliCare.WebApi.Adapters.Controllers
{
   [RoutePrefix("api/patients")]
   public class PatientsController : ApiController
   {
      private readonly IMediator _mediator;

      public PatientsController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [Route("")]
      public IEnumerable<PatientDto> GetPatients()
      {
         return _mediator.SendSync(new GetPatientsQuery());
      }

      [Route("create")]
      public PatientDto CreatePatient([FromBody]PatientNameDto name)
      {
         return _mediator.SendSync(new CreatePatientQuery() { PatientName = name });
      }
   }
}
