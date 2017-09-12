using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Ports.Repositories;

namespace CaliCare.Resources.Application.Commands.Handlers
{
   public class SeedDepartmentsCommandHandler : ICommandHandler<SeedDepartmentsCommand>
   {
      private readonly IDepartmentRepository _departmentRepository;

      public SeedDepartmentsCommandHandler(IDepartmentRepository departmentRepository)
      {
         _departmentRepository = departmentRepository;
      }

      public void Handle(SeedDepartmentsCommand message)
      {
         var departments = new Department[]
         {
            Department.Create("Los Gatos Radiation Oncology")
         };

         _departmentRepository.Store(departments);
      }
   }
}
