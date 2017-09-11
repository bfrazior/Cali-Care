using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CaliCare.WebApi.Adapters.Controllers
{
   [RoutePrefix("api/registration")]
   public class RegistrationController : ApiController
   {
      private readonly IMediator _mediator;

      public RegistrationController(IMediator mediator)
      {
         _mediator = mediator;
      }

      public void RegisterPatient()
      {
      }

      // GET: api/Registration
      public IEnumerable<string> Get()
      {
         return new string[] { "value1", "value2" };
      }

      // GET: api/Registration/5
      public string Get(int id)
      {
         return "value";
      }

      // POST: api/Registration
      public void Post([FromBody]string value)
      {
      }

      // PUT: api/Registration/5
      public void Put(int id, [FromBody]string value)
      {
      }

      // DELETE: api/Registration/5
      public void Delete(int id)
      {
      }
   }
}
