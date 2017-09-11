using System.Linq;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using System;

using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Queries.Handlers
{
   public class GetDepartmentQueryHandler : IQueryHandler<GetDepartmentByNameQuery, DepartmentDto>
   {
      private readonly IDepartmentRepository _departmentRepository;

      public GetDepartmentQueryHandler(IDepartmentRepository departmentRepository)
      {
         _departmentRepository = departmentRepository;
      }

      public DepartmentDto Handle(GetDepartmentByNameQuery message)
      {
         if (string.IsNullOrEmpty(message.Name))
            throw new ArgumentException($"{nameof(message.Name)} cannot be empty or undefined.");

         return ResourceConverter.ConvertToDto(_departmentRepository.Find(message.Name));
      }
   }
}
