using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.IO;

namespace MyCheerBook.Controllers
{
    public class TeamController : Controller
    {
        //Team Home Page
        public ActionResult Index(TeamVM vm)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices log = new TeamServices();
            Session["ProfileID"] = vm.ID;
            return View(vm);
        }

        //Creates a Team Page
        [HttpGet]
        public ActionResult CreatePage()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
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
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices log = new TeamServices();
            return PartialView("_RandomPic", log.RandomImage(Convert.ToInt32(Session["ProfileID"])));
        }

        //For putting adding news on team page
        [HttpGet]
        public ActionResult UpdateTeamNews()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
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

        //Team Name to be displayed(click links to team home page)
        public ActionResult TeamName()
        {
            if (Session["ProfileID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            return PartialView("_TeamName", ts.GetTeamByID(Convert.ToInt32(Session["ProfileID"])));
        }

        //View for Images
        public ActionResult Images()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            if (ts.IsExistingTeamMember(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])))
            {
                return View(ts.GetTeamImages(Convert.ToInt32(Session["ProfileID"])));
            }
            return View();
        }

        //Determines if a user has creditials to Delete things on team page
        public ActionResult Permissions(string view, int ID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            if (ts.Permissions(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])))
            {
                return PartialView(view, ID);
            }
            return PartialView(view, 0);
        }

        //For Deleting Images from teams
        public ActionResult DeleteImage(int imageID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            ts.DeleteImage(imageID, Convert.ToInt32(Session["ProfileID"]));
            return RedirectToAction("Images");
        }

        //Determines if a user has creditials to Add images on team page
        public ActionResult AddImage(string view)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            ImageFM fm = new ImageFM();
            if (!ts.IsExistingTeamMember(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])))
            {
                fm.Location = "No Premissions";
                return PartialView(view, fm);
            }
            return PartialView(view, fm);
        }

        //For Adding Images
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase file, ImageFM image)
        {
            AccountServices log = new AccountServices();
            TeamServices ts = new TeamServices();
            if (file != null && file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                if (!log.ValidImageExt(ext))
                {
                    return RedirectToAction("Images");
                }
                image.Location = ("Uploads/Images/" + log.RngString() + ext);
                while (System.IO.File.Exists(Server.MapPath("~/" + image.Location)))
                {
                    image.Location = ("Uploads/Images/" + log.RngString() + ext);
                }
                file.SaveAs(Server.MapPath("~/" + image.Location));
            }
            if (image.Location != null && image.Location != "No Premissions")
            {
                ts.AddImage(Convert.ToInt32(Session["ProfileID"]), image);
            }
            return RedirectToAction("Images");
        }

        //View for Videos
        public ActionResult Videos()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            if (ts.IsExistingTeamMember(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])))
            {
                return View(ts.GetTeamVideos(Convert.ToInt32(Session["ProfileID"])));
            }
            return View();
        }

        //For Deleting Video from teams
        public ActionResult DeleteVideo(int videoID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            ts.DeleteVideo(videoID, Convert.ToInt32(Session["ProfileID"]));
            return RedirectToAction("Videos");
        }

        //Determines if a user has creditials to Add video on team page
        public ActionResult AddVideo(string view)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            VideoFM fm = new VideoFM();
            if (!ts.IsExistingTeamMember(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])))
            {
                fm.Location = "No Premissions";
                return PartialView(view, fm);
            }
            return PartialView(view, fm);
        }

        //For Adding Videos
        [HttpPost]
        public ActionResult AddVideo(HttpPostedFileBase file, VideoFM video)
        {
            AccountServices log = new AccountServices();
            TeamServices ts = new TeamServices();
            if (file != null && file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                if (!log.ValidVideoExt(ext))
                {
                    return RedirectToAction("Videos");
                }
                video.Location = ("Uploads/Videos/" + log.RngString() + ext);
                while (System.IO.File.Exists(Server.MapPath("~/" + video.Location)))
                {
                    video.Location = ("Uploads/Videos/" + log.RngString() + ext);
                }
                file.SaveAs(Server.MapPath("~/" + video.Location));
            }
            if (video.Location != null && video.Location != "No Premissions")
            {
                ts.AddVideo(Convert.ToInt32(Session["ProfileID"]), video);
            }
            return RedirectToAction("Videos");
        }

        //A view of all the Members of a team
        public ActionResult Members()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            return View(ts.GetTeamMembers(Convert.ToInt32(Session["ProfileID"])));
        }

        //Button for joining team if not already on team(Or if not already pending request)
        public ActionResult Join()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            if (ts.RequestPeding(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])))
            {
                ViewBag.TeamMember = "Request Sent";
                return PartialView("_Join", true);
            }
            ViewBag.TeamMember = null;
            return PartialView("_Join", ts.IsExistingTeamMember(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])));
        }
        //Request to join a team(sends an email if available)
        public ActionResult JoinTeam()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            ts.TeamRequest(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"]));
            ViewBag.TeamMember = "Request Sent";
            return View("Index", ts.GetTeamByID(Convert.ToInt32(Session["ProfileID"])));
        }

        //Button for Managing Team Account
        public ActionResult ManageAccount()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            if(ts.IsCoach(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])))
            {
                return PartialView("_ManageAccount", ts.TeamJoinRequest(Convert.ToInt32(Session["ProfileID"])).Count);
            }
            return PartialView("_ManageAccount", 0);
        }

        //Handles Accepting and Denying Team Join Request
        public ActionResult PendingJoinRequest()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            return View(ts.TeamJoinRequest(Convert.ToInt32(Session["ProfileID"])));
        }
        public ActionResult AcceptRequest(int userID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            ts.AcceptRequest(userID, Convert.ToInt32(Session["ProfileID"]));
            return RedirectToAction("PendingJoinRequest");
        }
        public ActionResult DenyRequest(int userID) 
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            TeamServices ts = new TeamServices();
            ts.DenyRequest(userID, Convert.ToInt32(Session["ProfileID"]));
            return RedirectToAction("PendingJoinRequest");
        }

            
    }
}