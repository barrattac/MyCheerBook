using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCheerBook.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index()
        {
            return PartialView("_Search");
        }
        [HttpPost]
        public ActionResult Search(string word)
        {
            return View();
        }
	}
}