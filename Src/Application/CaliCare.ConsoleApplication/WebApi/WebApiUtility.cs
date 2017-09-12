using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Newtonsoft.Json;

namespace CaliCare.ConsoleApplication.WebApi
{
   public static class WebApiUtility
   {
      public static ByteArrayContent CreatePostContent(object value)
      {
         var content = JsonConvert.SerializeObject(value);
         var buffer = Encoding.UTF8.GetBytes(content);
         var byteContent = new ByteArrayContent(buffer);
         byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

         return byteContent;
      }
   }
}
