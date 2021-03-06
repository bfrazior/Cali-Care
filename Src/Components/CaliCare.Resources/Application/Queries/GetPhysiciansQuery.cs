﻿using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Resources.Ports.DataTransferObjects;
using CaliCare.Resources.Common;

namespace CaliCare.Resources.Application.Queries
{
   public class GetPhysiciansQuery : IQuery<IReadOnlyList<PhysicianDto>>
   {
      public PhysicianRole[] FilterRoles { get; set; }
   }
}
