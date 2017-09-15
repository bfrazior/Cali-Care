using System;
using System.Linq;

using MediatR;

using CaliCare.Conditions.Application.Queries;
using CaliCare.Conditions.Common;
using CaliCare.Infrastructure.Extensions;
using CaliCare.Resources.Application.Queries;
using CaliCare.Resources.Common;
using CaliCare.Schedule.Ports.Services;
using CaliCare.Schedule.Ports.DataTransferObjects;
using CaliCare.Resources.Domain;

namespace CaliCare.Schedule.Adapters.Services
{
   public class ConsultationService : IConsultationService
   {
      private readonly IMediator _mediator;

      public ConsultationService(IMediator mediator)
      {
         _mediator = mediator;
      }

      public Tuple<AppointmentStaffDto[], Guid[]> GetConsultationResources(Guid departmentId, Guid patientConditionId)
      {
         var condition = _mediator.SendSync(new GetConditionQuery() { Id = patientConditionId });

         if (condition.Type == ConditionType.Cancer)
         {
            var physicians = _mediator.SendSync(new GetPhysiciansQuery() { FilterRoles = new PhysicianRole[] { PhysicianRole.Oncologist } });

            var topog = _mediator.SendSync(new GetTopographyQuery() { Id = condition.TopogId.Value });

            var rooms = string.Equals(topog.Code, "Head & Neck", StringComparison.OrdinalIgnoreCase)
               ? _mediator.SendSync(new GetMachineRoomsQuery() { FilterAdvancedCapability = true })
               : _mediator.SendSync(new GetMachineRoomsQuery() { FilterAdvancedCapability = false });

            return new Tuple<AppointmentStaffDto[], Guid[]>(
               physicians.Select(x => new AppointmentStaffDto() { AppointmentStaffId = x.Id, AppointmentStaffType = nameof(Physician) }).ToArray(), 
               rooms.Select(x => x.Id).ToArray());
         }

         if (condition.Type == ConditionType.Flu)
         {
            var physicians = _mediator.SendSync(new GetPhysiciansQuery() { FilterRoles = new PhysicianRole[] { PhysicianRole.GeneralPractitioner } });
            var rooms = _mediator.SendSync(new GetNonMachineRoomsQuery() { DepartmentId = departmentId });

            return new Tuple<AppointmentStaffDto[], Guid[]>(
               physicians.Select(x => new AppointmentStaffDto() {AppointmentStaffId = x.Id, AppointmentStaffType = nameof(Physician) }).ToArray(), 
               rooms.Select(x => x.Id).ToArray());
         }

         return null;
      }
   }
}
