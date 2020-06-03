using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.Models;
namespace Marketing.Controllers
{
    public class UserTypeController : Controller
    {
        // GET: UserType
        public ActionResult Index()
        {
            return View(UserType.GetAll());
        }
        public ActionResult CreateEdit(int UserID)
        {
            UserType ObjUser = new UserType();
            if(UserID>0)
            {
                ObjUser = ObjUser.GetOne(UserID);
            }
            return View(ObjUser);
        }
        [HttpPost]
        public ActionResult CreateEdit(UserType ObjUser)
        {
            int d = ObjUser.Save();
            if (d > 0)
                return RedirectToAction("Index");
                return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            UserType ObjUser = new UserType();
            int d = ObjUser.Dell(ID);
            if (d > 0)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
    }
}