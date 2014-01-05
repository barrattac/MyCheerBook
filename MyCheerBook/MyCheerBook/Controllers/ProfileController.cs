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
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //Gets Profile Image for Profile
        public ActionResult ProfileImage()
        {
            AccountServices log = new AccountServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView(log.GetProfileImage((log.GetUserByID(Convert.ToInt32(Session["UserID"])))));
        }

        //Puts links on left side of Profile
        public ActionResult Links()
        {
            TeamServices log = new TeamServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView(log.GetUserTeams(Convert.ToInt32(Session["UserID"])));
        }

        //Image Page for User's Profile
        public ActionResult Images()
        {
            AccountServices log = new AccountServices();
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ImagesVM vm = log.GetUserImages(Convert.ToInt32(Session["UserID"]));
            return View(log.GetUserImages(Convert.ToInt32(Session["UserID"])));
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
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase file, ImageFM image)
        {
            AccountServices log = new AccountServices();
            if (file != null && file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                if (!log.ValidImageExt(ext))
                {
                    ViewBag.Upload = "Upload failed.  Wrong file type. File must be in GIF, JPG or PNG format.";
                    return RedirectToAction("Images");
                }
                image.Location = ("Uploads/Images/" + log.RngString() + ext);
                while (System.IO.File.Exists(Server.MapPath("~/" + image.Location)))
                {
                    image.Location = ("Uploads/Images/" + log.RngString() + ext);
                }
                file.SaveAs(Server.MapPath("~/" + image.Location));
                log.AddImage(Convert.ToInt32(Session["UserID"]), image);
            }
            ViewBag.Upload = "Image Uploaded";
            return RedirectToAction("Images");
        }

        //Deletes Image from User's Images
        public ActionResult DeleteImage(int imageID)
        {
            AccountServices log = new AccountServices();
            log.DeleteUserImage(Convert.ToInt32(Session["UserID"]), imageID);
            return RedirectToAction("Images");
        }


        //Needs View
        public ActionResult Videos()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
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