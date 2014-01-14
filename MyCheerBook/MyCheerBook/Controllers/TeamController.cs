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

        //For putting news on team page
        [HttpGet]
        public ActionResult UpdateTeamNew()
        {
            //Create view for updating team new
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdateTeamNew(StatusFM news)
        {
            //Insert Code for adding team news
            return RedirectToAction("Index");
        }


        //Needs View for following
        //Images
        //Videos
        //Members
    }
}