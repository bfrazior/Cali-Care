using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application.Queries
{
   public class GetDepartmentsQuery : IQuery<IReadOnlyList<DepartmentDto>>
   {
   }
}
