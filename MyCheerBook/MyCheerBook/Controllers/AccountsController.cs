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
            }
            return RedirectToAction("Index", "Home");
        }
	}
}