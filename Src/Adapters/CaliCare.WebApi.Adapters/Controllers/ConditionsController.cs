using System;
using System.Collections.Generic;
using System.Web.Http;

using MediatR;

using CaliCare.Conditions.Application.Queries;
using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Extensions;

namespace CaliCare.WebApi.Adapters.Controllers
{
   [RoutePrefix("api/conditions")]
   public class ConditionsController : ApiController
    {
      private readonly IMediator _mediator;

      public ConditionsController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [Route("create")]
      public PatientConditionDto CreateCondition([FromBody]PatientConditionDto condition)
      {
         return _mediator.SendSync(new CreateConditionQuery() { Condition = condition });
      }

      [Route("")]
      public IEnumerable<PatientConditionDto> GetConditions()
      {
         return _mediator.SendSync(new GetConditionsQuery());
      }

      [Route("topogs")]
      public IEnumerable<TopographyDto> GetTopographies()
      {
         return _mediator.SendSync(new GetTopographiesQuery());
      }

      [Route("topogs/{id:Guid}")]
      public TopographyDto GetTopography(Guid id)
      {
         return _mediator.SendSync(new GetTopographyQuery() { Id = id });
      }
   }
}
