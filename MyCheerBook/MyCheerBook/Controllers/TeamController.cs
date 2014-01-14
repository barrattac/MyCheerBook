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
        //Team Home Page
        public ActionResult Index(TeamVM team)
        {
            Session["ProfileID"] = team.ID;
            return View(team.TeamName);
        }

        //Creates a Team Page
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

        //Picks a random pic from team's images
        public ActionResult RandomPic()
        {
            TeamServices log = new TeamServices();
            return PartialView("_RandomPic", log.RandomImage(Convert.ToInt32(Session["ProfileID"])));
        }

    }
}