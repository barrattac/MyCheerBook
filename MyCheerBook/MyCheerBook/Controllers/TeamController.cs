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
        public ActionResult Index(TeamVM vm)
        {
            TeamServices log = new TeamServices();
            Session["ProfileID"] = vm.ID;
            return View(vm);
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

        //For putting adding news on team page
        [HttpGet]
        public ActionResult UpdateTeamNews()
        {
            StatusFM fm = new StatusFM();
            TeamServices log = new TeamServices();
            //Determines if the user is part of the team
            if (log.IsExistingTeamMember(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])))
            {
                fm.UserID = Convert.ToInt32(Session["UserID"]);
            }
            return PartialView("UpdateTeamNews", fm);
        }
        [HttpPost]
        public ActionResult UpdateTeamNews(StatusFM news)
        {
            //Insert Code for adding team news
            StatusServices log = new StatusServices();
            TeamServices ts = new TeamServices();
            news.UserID = Convert.ToInt32(Session["UserID"]);
            log.UpdateTeamNews(Convert.ToInt32(Session["ProfileID"]), news);
            return RedirectToAction("Index", ts.GetTeamByID(Convert.ToInt32(Session["ProfileID"])));
        }



        //Needs View for following
        //Images
        //Videos
        //Members
    }
}