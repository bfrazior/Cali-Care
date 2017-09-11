using System.Linq;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetDepartmentsQueryHandler : IQueryHandler<GetDepartmentsQuery, IReadOnlyList<DepartmentDto>>
   {
      private readonly IDepartmentRepository _departmentRepository;

      public GetDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
      {
         _departmentRepository = departmentRepository;
      }

      public IReadOnlyList<DepartmentDto> Handle(GetDepartmentsQuery message)
         => _departmentRepository.FindAll().Select(x => ResourceConverter.ConvertToDto(x)).ToList();
   }
}
