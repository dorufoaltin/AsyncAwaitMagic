using AgileHub.AsyncAwaitMagic.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileHub.AsyncAwaitMagic.AspNetWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            RestClient restClient = new RestClient();

            var result = restClient.Get("http://asyncawaitmagic.azurewebsites.net/api/demo").Result;

            return result.StatusCode.ToString();
        }
    }
}
