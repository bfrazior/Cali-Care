using System.Collections.Generic;
using System.Web.Http;

using MediatR;

using CaliCare.Resources.Application.Queries;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Infrastructure.Extensions;

namespace CaliCare.WebApi.Adapters.Controllers
{
   [RoutePrefix("api/resources")]
   public class ResourcesController : ApiController
   {
      private readonly IMediator _mediator;

      public ResourcesController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [Route("machines/{filterAdvanced:bool}")]
      public IEnumerable<MachineDto> GetMachines(bool filterAdvanced)
      {
         return _mediator.SendSync(new GetMachinesQuery() { FilterAdvancedMachines = filterAdvanced });
      }

      [Route("departments")]
      public IEnumerable<DepartmentDto> GetDepartments()
      {
         return _mediator.SendSync(new GetDepartmentsQuery());
      }

      // GET: api/Resource
      public IEnumerable<string> Get()
      {
         return new string[] { "value1", "value2" };
      }

      // GET: api/Resource/5
      public string Get(int id)
      {
         return "value";
      }

      // POST: api/Resource
      public void Post([FromBody]string value)
      {
      }

      // PUT: api/Resource/5
      public void Put(int id, [FromBody]string value)
      {
      }

      // DELETE: api/Resource/5
      public void Delete(int id)
      {
      }
   }
}
