using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

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
        public ActionResult CreatePage(TeamFM team)
        {
            TeamServices log = new TeamServices();
            if (!log.IsExistingTeam(team.Email))
            {
                    log.CreateTeam(team, Convert.ToInt32(Session["UserID"]));
                    return RedirectToAction("Index", "Profile");
            }
            ViewBag.ErrorMessage = "Team already exist.";
            return View();
        }
    }
}