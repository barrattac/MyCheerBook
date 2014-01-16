using System;
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
        
        //Login Page
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

        //Change Password
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(PasswordFM pass)
        {
            AccountServices log = new AccountServices();
            if (log.ValidPasswords(pass))
            {
                log.ChangePassword(pass);
                return RedirectToAction("Index", "Profile");
            }
            ViewBag.ErrorMessage = "Your password was not changed.  Try again.";
            return View();
        }

        //Manage Account/Profile
        [HttpGet]
        public ActionResult Edit()
        {
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
            return View(fm);
        }
    }
}