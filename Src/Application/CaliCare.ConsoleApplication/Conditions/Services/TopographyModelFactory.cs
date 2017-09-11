using CaliCare.Conditions.Ports.DataTransferObjects;
using CaliCare.ConsoleApplication.Conditions.Models;

namespace CaliCare.ConsoleApplication.Conditions.Services
{
   public static class TopographyModelFactory
   {
      public static TopographyModel Create(TopographyDto topogDto)
      {
         if (topogDto == null)
            return null;

         return new TopographyModel()
         {
            Classification = topogDto.Classification,
            Code = topogDto.Code,
            Id = topogDto.Id
         };
      }
   }
}
