using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgileHub.AsyncAwaitMagic.AspNetCoreMvc.Models;
using AgileHub.AsyncAwaitMagic.Standard;

namespace AgileHub.AsyncAwaitMagic.AspNetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            RestClient restClient = new RestClient();

            var result = restClient.Get("http://asyncawaitmagic.azurewebsites.net/api/demo").Result;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
