using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using CaliCare.Schedule.Domain;
using CaliCare.Schedule.Ports.Repositories;
using CaliCare.Infrastructure.Utilities;

namespace CaliCare.Schedule.Adapters.Repositories
{
   public class AppointmentRepository : IAppointmentRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "appointments.json");

      public Appointment Find(Guid id)
         => FindAll().Where(x => x.Id == id).SingleOrDefault();

      public IReadOnlyList<Appointment> FindAll()
      {
         try { return JsonConvert.DeserializeObject<Appointment[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<Appointment>(); }
      }

      public IReadOnlyList<Appointment> FindAllByClinicalActivityId(Guid clinicalActivityId)
         => FindAll().Where(x => x.ClinicalActivityId == clinicalActivityId).ToList();

      public void Store(Appointment[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));

      public void Store(Appointment appointment)
      {
         var appointments = FindAll().ToList();
         appointments.Add(appointment);
         Store(appointments.ToArray());
      }
   }
}
