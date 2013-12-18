using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCheerBook.Controllers
{
    public class TeamController : Controller
    {
        //
        // GET: /Team/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreatePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePage()
        {
            return View();
        }

	}
}