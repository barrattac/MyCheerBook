using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCheerBook.Controllers
{
    public class HomeController : Controller
    {
        //MyCheerBook Home Page
        public ActionResult Index()
        {
            return View();
        }

        //About Page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        //Contact Page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}