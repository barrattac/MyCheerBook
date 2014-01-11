﻿using System;
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
            Session["UserID"] = Session["ProfileID"];
            return View();
        }

        //Friend's Profile
        public ActionResult FriendsPage(int ID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            Session["ProfileID"] = ID;
            return View("Index");
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

        //Needs View
        public ActionResult Friends()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
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