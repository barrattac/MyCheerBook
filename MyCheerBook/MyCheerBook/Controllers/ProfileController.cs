using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.IO;

namespace MyCheerBook.Controllers
{
    public class ProfileController : Controller
    {
        //User Profile Page
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            Session["ProfileID"] = Session["UserID"];
            return View();
        }

        //Friend's Profile
        public ActionResult FriendsPage(int ID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ID == Convert.ToInt32(Session["UserID"]))
            {
                return RedirectToAction("Index");
            }
            Session["ProfileID"] = ID;
            return View("Index");
        }

        //Nav Bar for Friends Profile(add request and such)
        public ActionResult TopProfileNav()
        {
            AccountServices log = new AccountServices();
            return PartialView("_TopProfileNav", log.GetUserByID(Convert.ToInt32(Session["ProfileID"])));
        }

        //Gets Profile Image for Profile
        public ActionResult ProfileImage()
        {
            AccountServices log = new AccountServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView(log.GetProfileImage((log.GetUserByID(Convert.ToInt32(Session["ProfileID"])))));
        }

        //Puts links on left side of Profile
        public ActionResult Links()
        {
            TeamServices log = new TeamServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView(log.GetUserTeams(Convert.ToInt32(Session["ProfileID"])));
        }

        //Image Page for User's Profile
        public ActionResult Images()
        {
            AccountServices log = new AccountServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(log.GetUserImages(Convert.ToInt32(Session["ProfileID"])));
        }

        //Adds Image to User
        [HttpGet]
        public ActionResult AddImage()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView();
        }
        //Adds Image from File
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase file, ImageFM image)
        {
            AccountServices log = new AccountServices();
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
            if(image.Location != null)
            {
                
                log.AddImage(Convert.ToInt32(Session["UserID"]), image);
            }
            return RedirectToAction("Images");
        }

        //Deletes Image from User's Images
        public ActionResult DeleteImage(int imageID)
        {
            AccountServices log = new AccountServices();
            log.DeleteUserImage(Convert.ToInt32(Session["UserID"]), imageID);
            return RedirectToAction("Images");
        }

        //Video Page for User's Profile
        public ActionResult Videos()
        {
            AccountServices log = new AccountServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(log.GetUserVideos(Convert.ToInt32(Session["ProfileID"])));
        }

        //Adds Video to User
        [HttpGet]
        public ActionResult AddVideo()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddVideo(HttpPostedFileBase file, VideoFM video)
        {
            AccountServices log = new AccountServices();
            if (file != null && file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                if (!log.ValidVideoExt(ext))
                {
                    ViewBag.Upload = "Upload failed.  Wrong file type. File must be in MP4, WebM, or Ogg format.";
                    return RedirectToAction("Videos");
                }
                video.Location = ("Uploads/Videos/" + log.RngString() + ext);
                while (System.IO.File.Exists(Server.MapPath("~/" + video.Location)))
                {
                    video.Location = ("Uploads/Videos/" + log.RngString() + ext);
                }
                file.SaveAs(Server.MapPath("~/" + video.Location));
                log.AddVideo(Convert.ToInt32(Session["UserID"]), video);
            }
            ViewBag.Upload = "Video Uploaded";
            return RedirectToAction("Videos");
        }

        //Deletes Video from User's Videos
        public ActionResult DeleteVideo(int videoID)
        {
            AccountServices log = new AccountServices();
            log.DeleteUserVideo(Convert.ToInt32(Session["UserID"]), videoID);
            return RedirectToAction("Videos");
        }

        //Button for adding or deleting friends
        public ActionResult FriendRequest()
        {
            FriendServices log = new FriendServices();
            if (Convert.ToInt32(Session["UserID"]) != Convert.ToInt32(Session["ProfileID"]))
            {
                return PartialView("_FriendRequest", log.Friends(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])));
            }
            return PartialView("_FriendRequest", log.PendingRequest(Convert.ToInt32(Session["UserID"])));
        }

        //Link to page for viewing friend request
        public ActionResult ViewPendingRequest()
        {
            return View("PendingRequest");
        }

        //People that you requested as a friend
        public ActionResult YourRequest()
        {
            FriendServices fs = new FriendServices();
            return PartialView("_YourRequest", fs.WaitingResponse(Convert.ToInt32(Session["UserID"])));
        }

        //People that requested you as a friend
        public ActionResult RequestedYou()
        {
            FriendServices fs = new FriendServices();
            return PartialView("_RequestedYou", fs.YourRequest(Convert.ToInt32(Session["UserID"])));
        }
          
        //Unfriend someone and redirect to Profile
        public ActionResult UnFriend()
        {
            FriendServices fs = new FriendServices();
            fs.UnFriend(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"]));
            return View("Index");
        }

        //Request Friend and redirect to Profile
        public ActionResult SendRequest()
        {
            FriendServices fs = new FriendServices();
            fs.SendRequest(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"]));
            return View("Index");
        }

        //Cancel Friend Request
        public ActionResult CancelRequest(int friendID)
        {
            FriendServices fs = new FriendServices();
            fs.UnFriend(Convert.ToInt32(Session["UserID"]), friendID);
            return View("Index");
        }

        //Accepts Friend Request
        public ActionResult MakeFriends(int friendID)
        {
            FriendServices fs = new FriendServices();
            fs.MakeFriends(Convert.ToInt32(Session["UserID"]), friendID);
            return View("Index");
        }

        //View for user's Friends
        public ActionResult Friends()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            FriendServices fs = new FriendServices();
            return View(fs.GetFriends(Convert.ToInt32(Session["ProfileID"])));
        }

        //Friends Profile Pic for List of Friends
        public ActionResult FriendPic(int friendID)
        {
            AccountServices log = new AccountServices();
            ImageVM vm = log.GetProfileImage(log.GetUserByID(friendID));
            return PartialView("_FriendPic", vm.Location);
        }

        //For add a user status
        [HttpGet]
        public ActionResult UpdateStatus()
        {
            return PartialView("_UpdateStatus");
        }
        [HttpPost]
        public ActionResult UpdateStatus(StatusFM fm)
        {
            StatusServices ss = new StatusServices();
            fm.UserID = Convert.ToInt32(Session["UserID"]);
            ss.AddStatus(fm);
            return RedirectToAction("Index");
        }

        //For viewing status
        public ActionResult Status()
        {
            StatusServices ss = new StatusServices();
            return PartialView("_Status", ss.GetStatus(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["ProfileID"])));
        }




        //Needs View
        public ActionResult StatusFeed()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
       
 

        //Team Page
        public ActionResult TeamPage(TeamVM team)
        {
            return View(team);
        }
    }
}