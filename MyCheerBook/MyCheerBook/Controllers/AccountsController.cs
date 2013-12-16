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
        //
        // GET: /Accounts/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserFM user)
        {
            AccountServices log = new AccountServices();
            if (!log.IsExistingUser(user.Email) && user.Email.Length > 5 && user.Password.Length > 7)
            {
                log.CreateUser(user);
                return RedirectToAction("Index", "Home");
            }
            if (log.IsExistingUser(user.Email))
            {
                ViewBag.ErrorMessage = "Email Address already in use.";
                return View();
            }
            ViewBag.ErrorMessage = "Password not valid.";
            return View();
        }
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
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");

        }
    }
}