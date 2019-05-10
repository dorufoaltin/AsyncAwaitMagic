using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.Standard
{
    public class DemoService
    {
        private string _baseUrl = "http://asyncawaitmagic.azurewebsites.net/api/";

        public async Task<bool> SaveNewDemoText(string value)
        {
            RestClient restClient = new RestClient();

            return await restClient.Post<bool, string>(value, _baseUrl + "demo");
        }

        public bool SaveNewDemoTextSyncHack(string value)
        {
            RestClient restClient = new RestClient();

            return restClient.Post<bool, string>(value, _baseUrl + "demo").Result;
        }
    }
}
