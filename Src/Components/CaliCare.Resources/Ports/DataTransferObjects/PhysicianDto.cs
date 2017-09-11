using System;

using CaliCare.Resources.Common;

namespace CaliCare.Resources.Ports.DataTransferObjects
{
   public class PhysicianDto
   {
      public Guid Id { get; set; }
      public PhysicianNameDto Name { get; set; }
      public PhysicianRole[] Roles { get; set; }
   }

   public class PhysicianNameDto
   {
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }
      public string UserName { get; set; }
   }
}
