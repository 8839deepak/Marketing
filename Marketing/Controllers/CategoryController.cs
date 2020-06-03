using Marketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketing.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(Category.GetAll());
        }
        public ActionResult CreateEdit(int CatID)
        {
            Category ObjUser = new Category();
            if (CatID > 0)
            {
                ObjUser = ObjUser.GetOne(CatID);
            }
            return View(ObjUser);
        }
        [HttpPost]
        public ActionResult CreateEdit(Category ObjUser)
        {
            int d = ObjUser.Save();
            if (d > 0)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            Category ObjUser = new  Category();
            int d = ObjUser.Dell(ID);
            if (d > 0)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
    }
}