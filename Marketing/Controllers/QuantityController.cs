using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.Models;
namespace Marketing.Controllers
{
    public class QuantityController : Controller
    {
        // GET: Quantity
        public ActionResult Index()
        {
            return View(Quantity.GetAll());
        }
        //public ActionResult CreateEdit(int QunID)
        //{
        //    Quantity ObjQuantity = new Quantity();
        //    if(QunID>0)
        //    {
        //        ObjQuantity = ObjQuantity.GetOne(QunID);
        //    }
        //    return View(ObjQuantity);
        //}
        //[HttpPost]
        //public ActionResult CreateEdit(Quantity ObjQuantity)
        //{
        //    int d = ObjQuantity.Save();
        //    if (d > 0)
        //        return RedirectToAction("Index");
        //        return RedirectToAction("Index");
        //}
        //public ActionResult Delete(int id)
        //{
        //    Quantity quantity = new Quantity();
        //    int d = quantity.Dell(id);
        //    if(d>0)
        //        return RedirectToAction("Index");
        //    return RedirectToAction("Index");
        //}
        
    }
   
}