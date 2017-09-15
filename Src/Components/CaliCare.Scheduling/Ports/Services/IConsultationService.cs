using System;

using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Ports.Services
{
   public interface IConsultationService
   {
      Tuple<AppointmentStaffDto[], Guid[]> GetConsultationResources(Guid departmentId, Guid patientConditionId);
   }
}
