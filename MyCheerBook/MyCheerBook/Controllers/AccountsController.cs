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
        //registration Page
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserFM user)
        {
            AccountServices log = new AccountServices();
            if (!log.IsExistingUser(user.Email) && log.ValidEmail(user.Email))
            {
                if (log.ValidPassword(user.Password) && user.Password == user.ConfirmPassword)
                {
                    log.CreateUser(user);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorMessage = "Passwords are not valid.  Password must be atleast 8 characters and match.";
            }
            if (log.IsExistingUser(user.Email))
            {
                ViewBag.ErrorMessage = "Email Address already in use.";
            }
            return View();
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
                    return RedirectToAction("Index", "Profile");
                }
            }
            ViewBag.ErrorMessage = "Login Credentials Not Valid.";
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
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
    }
}