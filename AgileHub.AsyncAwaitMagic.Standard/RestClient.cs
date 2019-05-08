using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.Standard
{
    public class RestClient 
    {
        public async Task<HttpResponseMessage> Get(string url)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage result = await httpClient.GetAsync(url);

            if (!result.IsSuccessStatusCode)
                Console.WriteLine($"request failed for {url}");

            return result;
        }

        public async Task<T> Get<T>(string url)
        {
            Console.WriteLine($"Trying to get the value for {url}");

            var httpResult = await Get(url);

            if (httpResult.IsSuccessStatusCode)
            {
                Console.WriteLine($"request succcesfull for {url}");

                var stringResult = await httpResult.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(stringResult);
            }

            return default(T);
        }
    }
}
