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
            DemoService service = new DemoService();

            var saveResult = service.SaveNewDemoTextSyncHack("someValue");

            return $"Reached the end with result: {saveResult}!";
        }
    }
}
