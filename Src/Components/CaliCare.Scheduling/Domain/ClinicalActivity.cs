using System;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Schedule.Domain
{
   public class ClinicalActivity : IAggregateRoot
   {
      public Guid Id { get; }
      public string Code { get; }
      public string Group { get; }
      public string Name { get; }

      public ClinicalActivity(Guid id, string group, string code, string name)
      {
         Id = id;
         Code = code;
         Group = group;
         Name = name;
      }

      public static ClinicalActivity Create(string group, string code, string name)
         => new ClinicalActivity(Guid.NewGuid(), group, code, name);
   }
}
