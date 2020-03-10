using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhoLetDerHundOut.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "We know dogs are exciting but please take a second to learn about the creators.";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "This is the help page.  Not sure why you would need help this site is very simple.";

            return View();
        }
    }
}