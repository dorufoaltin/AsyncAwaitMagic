using AgileHub.AsyncAwaitMagic.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileHub.AsyncAwaitMagic.AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            RestClient restClient = new RestClient();

            var result = restClient.Get("http://asyncawaitmagic.azurewebsites.net/api/demo").Result;

            ViewBag.Message = result.StatusCode.ToString();

            return View();
        }
    }
}