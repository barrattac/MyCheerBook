﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace MyCheerBook.Controllers
{
    public class AccountsController : Controller
    {
        //Registration Code
        [HttpPost]
        public ActionResult Register(UserFM user)
        {
            AccountServices log = new AccountServices();
            if (!log.IsExistingUser(user.Email) && log.ValidEmail(user.Email))
            {
                if (log.ValidPassword(user.Password) && user.Password == user.ConfirmPassword)
                {
                    log.CreateUser(user);
                    Session["UserID"] = log.GetUserByEmail(user.Email).ID;
                    Session["UserName"] = user.FirstName + " " + user.LastName;
                    Session["ProfileID"] = Session["UserID"];
                    return RedirectToAction("Index", "Profile");
                }
                ViewBag.RegisterError = "Passwords are not valid.  Password must be atleast 8 characters and match.";
            }
            else
            {
                ViewBag.RegisterError = "Email not valid.";
            }
            if (log.IsExistingUser(user.Email))
            {
                ViewBag.RegisterError = "Email Address already in use.";
            }
            return View("Login");
        }

        //Login and Registration Page
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserFM userFM)
        {
            AccountServices log = new AccountServices();
            if (log.IsExistingUser(userFM.Email))
            {
                UserVM user = log.Login(userFM);
                if (user != null)
                {
                    Session["UserID"] = user.ID;
                    Session["UserName"] = user.FirstName + " " + user.LastName;
                    Session["ProfileID"] = Session["UserID"];
                    return RedirectToAction("Index", "Profile");
                }
            }
            ViewBag.LoginError = "Login Credentials Not Valid.";
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["ProfileID"] = null;
            return RedirectToAction("Index", "Home");
        }

        //Manage Account Profile
        [HttpGet]
        public ActionResult Edit()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            AccountServices log = new AccountServices();
            UserFM fm = new UserFM();
            fm.FirstName = log.GetUserByID(Convert.ToInt32(Session["UserID"])).FirstName;
            fm.LastName = log.GetUserByID(Convert.ToInt32(Session["UserID"])).LastName;
            fm.Email = log.GetUserByID(Convert.ToInt32(Session["UserID"])).Email;
            return View(fm);
        }
        [HttpPost]
        public ActionResult Edit(UserFM fm)
        {
            AccountServices log = new AccountServices();
            fm.ID = Convert.ToInt32(Session["UserID"]);
            ViewBag.Error = log.UpdateUser(fm);
            return View(fm);
        }

        //Deletes Teams from Profile
        public ActionResult EditTeams()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            TeamServices ts = new TeamServices();
            return PartialView(ts.GetUserTeams(Convert.ToInt32(Session["UserID"])).Teams);
        }
        public ActionResult DeleteTeam(int teamID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            TeamServices ts = new TeamServices();
            ts.DenyRequest(Convert.ToInt32(Session["UserID"]), teamID);
            return RedirectToAction("Edit");
        }

        //Registration Code for Event Organizers
        [HttpPost]
        public ActionResult EventOrganizerRegister(OrganizerFM fm)
        {
            OrganizerServices log = new OrganizerServices();
            AccountServices services = new AccountServices();
            if (!log.IsExistingOrganization(fm.Email))
            {
                if (services.ValidEmail(fm.Email))
                {
                    if (fm.Password != null && services.ValidPassword(fm.Password) && fm.Password == fm.ConfirmPass)
                    {
                        log.CreateOrganization(fm);
                        Session["OrganizerID"] = log.GetOrganizerByEmail(fm.Email).ID;
                        return View();
                    }
                    ViewBag.RegisterError = "Password was not valid.";
                    return View("EventOrganizerLogin");
                }
                ViewBag.RegisterError = "That email is not valid.";
                return View("EventOrganizerLogin");

            }
            ViewBag.RegisterError = "That organization already exist.";
            return View("EventOrganizerLogin");
        }

        //Login and Registration for Event Organizers
        [HttpGet]
        public ActionResult EventOrganizerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EventOrganizerLogin(OrganizerFM fm)
        {
            return View();
        }

    }
}