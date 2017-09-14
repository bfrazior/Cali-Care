using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using CaliCare.Patients.Ports.Repositories;
using CaliCare.Patients.Domain;
using CaliCare.Infrastructure.Utilities;

namespace CaliCare.Patients.Adapters.Repositories
{
   public class PatientRepository : IPatientRepository
   {
      private readonly string _jsonPath = Path.Combine(AppDomainUtility.GetAppDomainPath(), "patients.json");

      public Patient Find(Guid id)
         => FindAll().Where(x => x.Id == id).SingleOrDefault();

      public IReadOnlyList<Patient> FindAll()
      {
         try { return JsonConvert.DeserializeObject<Patient[]>(File.ReadAllText(_jsonPath)).ToList(); }
         catch { return new List<Patient>(); }
      }

      public void Store(Patient[] aggregates)
         => File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(aggregates));

      public void Store(Patient patient)
      {
         var patients = new List<Patient>(FindAll());
         patients.Add(patient);
         File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(patients));
      }
   }
}
