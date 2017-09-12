using System;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Ports.DataTransferObjects;

namespace CaliCare.Resources.Application
{
   internal static class ResourceConverter
   {
      public static Physician ConvertToDomain(PhysicianDto physicianDto)
         => physicianDto == null ? null : new Physician(
            physicianDto.Id,
            ConvertToDomain(physicianDto.Name),
            physicianDto.Roles);

      public static PhysicianName ConvertToDomain(PhysicianNameDto name)
         => name == null ? null : new PhysicianName(
            name.FirstName,
            name.MiddleName,
            name.LastName,
            name.UserName);

      public static PhysicianDto ConvertToDto(Physician physician)
         => physician == null ? null : new PhysicianDto()
         {
            Id = physician.Id,
            Name = ConvertToDto(physician.Name),
            Roles = physician.Roles
         };

      public static PhysicianNameDto ConvertToDto(PhysicianName physicianName)
         => physicianName == null ? null : new PhysicianNameDto()
         {
            FirstName = physicianName.FirstName,
            LastName = physicianName.LastName,
            MiddleName = physicianName.MiddleName,
            UserName = physicianName.UserName
         };

      public static MachineDto ConvertToDto(Machine machine)
         => machine == null ? null : new MachineDto()
         {
           Characterization = ConvertToDto(machine.Characterization),
           Id = machine.Id,
           Name = machine.Name,
           RoomId = machine.RoomId 
         };

      public static MachineCharacterizationDto ConvertToDto(MachineCharacterization characterization)
         => characterization == null ? null : new MachineCharacterizationDto()
         {
            Capability = characterization.Capability
         };

      public static DepartmentDto ConvertToDto(Department department)
         => department == null ? null : new DepartmentDto()
         {
            Id = department.Id,
            Name = department.Name
         };

      public static RoomDto ConvertToDto(Room room)
         => room == null ? null : new RoomDto()
         {
            DepartmentId = room.DepartmentId,
            Id = room.Id,
            Name = room.Name
         };
   }
}
