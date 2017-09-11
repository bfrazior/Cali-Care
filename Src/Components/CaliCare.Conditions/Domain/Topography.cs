using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Conditions.Common;

namespace CaliCare.Conditions.Domain
{
   public class Topography : IAggregateRoot
   {
      public Guid Id { get; }
      public TopographyClassification Classification { get; }
      public string Code { get; }

      public Topography(Guid id, string code, TopographyClassification classification)
      {
         Id = id;
         Code = code;
         Classification = classification;
      }

      public static Topography Create(string code, TopographyClassification classification)
         => new Topography(Guid.NewGuid(), code, classification);
   }
}
