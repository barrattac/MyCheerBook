using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

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
        public ActionResult SearchUsers(string word)
        {
            SearchServices log = new SearchServices();
            return View("_Results", log.SearchUsers(word, Convert.ToInt32(Session["UserID"])));
        }
	}
}