using System;
using System.IO;

namespace CaliCare.Infrastructure.Utilities
{
   public static class AppDomainUtility
   {
      public static string GetAppDomainPath()
         => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
   }
}
