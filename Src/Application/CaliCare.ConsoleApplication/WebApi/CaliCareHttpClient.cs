using System;
using System.Net.Http;

namespace CaliCare.ConsoleApplication.WebApi
{
   public class CaliCareHttpClient : HttpClient
   {
      public CaliCareHttpClient()
      {
         BaseAddress = new Uri("http://localhost:60098/");

         DefaultRequestHeaders.Accept.Clear();
         DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
      }
   }
}
