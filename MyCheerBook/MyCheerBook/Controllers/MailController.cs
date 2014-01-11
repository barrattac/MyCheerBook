﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace MyCheerBook.Controllers
{
    public class MailController : Controller
    {
        //To recover password
        [HttpGet]
        public ActionResult ForgotPass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPass(UserFM fm)
        {
            MailServices log = new MailServices();
            if (log.ForgotPass(fm))
            {
                ViewBag.Error = "Check Email for Password.";
                return View("~/Views/Accounts/Login.cshtml");
            }
            ViewBag.Error = "Your first and last name did not match with email.";
            return View();
        }
    }
}