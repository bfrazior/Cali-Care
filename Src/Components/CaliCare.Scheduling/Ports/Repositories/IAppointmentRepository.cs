﻿using System;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Domain;

namespace CaliCare.Schedule.Ports.Repositories
{
   public interface IAppointmentRepository : IRepository<Appointment>
   {
      void Store(Appointment appointment);

      Appointment Find(Guid id);

      IReadOnlyList<Appointment> FindAllByClinicalActivityId(Guid clinicalActivityId);
   }
}
