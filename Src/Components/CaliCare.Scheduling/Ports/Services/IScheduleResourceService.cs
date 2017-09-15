using System;

namespace CaliCare.Schedule.Ports.Services
{
   public interface IScheduleResourceService
   {
      Guid[] GetPhysiciansByRole(string role);

      Guid[] GetNonMachineRooms(Guid departmentId);

      Guid[] GetMachineRooms(bool filterAdvancedCapability);
   }
}
