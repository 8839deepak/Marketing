using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Marketing.Models;
namespace Marketing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            ViewData["Mgs"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult LoginPost(Login Objlogin)
        {
            List<Login> listlogin = new Login().GetAll();
            listlogin = listlogin.FindAll(x=>x.UserName==Objlogin.UserName &&x.Password==Objlogin.Password);
            if (Objlogin!=null)
            {
                Session["LoginID"] = Objlogin.UserID;
                Session["UserID"] = Objlogin.UserID;
                return RedirectToAction("Admin");
            }
            ViewData["Mgs"] = "UserName And Password are Wrong";
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult ItemLoadFunction()
        {
            return View( );
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login", "Home");
        }
        public ActionResult PopUp()
        {
            return View();
        }
    }
}