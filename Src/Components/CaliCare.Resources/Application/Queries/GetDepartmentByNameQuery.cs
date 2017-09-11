using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Queries
{
   public class GetDepartmentByNameQuery : IQuery<DepartmentDto>
   {
      public string Name { get; set; }
   }
}
