using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
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
            {
                Console.WriteLine($"request failed for {url}");
            }

            return result;
        }
    }
}
