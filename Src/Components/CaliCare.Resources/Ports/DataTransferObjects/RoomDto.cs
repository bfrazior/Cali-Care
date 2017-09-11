using System;

namespace CaliCare.Resources.Ports.DataTransferObjects
{
   public class RoomDto
   {
      public Guid Id { get; set; }
      public Guid DepartmentId { get; set; }
      public string Name { get; set; }
   }
}
