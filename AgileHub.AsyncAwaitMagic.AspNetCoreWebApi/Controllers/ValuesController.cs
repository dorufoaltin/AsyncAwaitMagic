using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileHub.AsyncAwaitMagic.Standard;
using Microsoft.AspNetCore.Mvc;

namespace AgileHub.AsyncAwaitMagic.AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            DemoService service = new DemoService();

            var saveResult = service.SaveNewDemoTextSyncHack("someValue");

            return $"Reached the end with result: {saveResult}!";
        }
    }
}
