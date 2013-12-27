using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace MyCheerBook.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult ProfileImage()
        {
            AccountServices log = new AccountServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(log.GetProfileImage((log.GetUserByID(Convert.ToInt32(Session["UserID"])))));
        }
        public ActionResult Links()
        {
            TeamServices log = new TeamServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(log.GetUserTeams(Convert.ToInt32(Session["UserID"])));
        }
        public ActionResult TeamPage(TeamVM team)
        {
            return View(team);
        }
    }
}