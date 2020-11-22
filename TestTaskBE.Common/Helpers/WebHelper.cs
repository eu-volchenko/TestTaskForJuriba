using Newtonsoft.Json;
using System.Net;

namespace TestTaskBE.Common.Helpers
{
    public static class WebHelper
    {
        public static T Get<T>(string uri) where T : class, new()
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(uri);

                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
