using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Marketing.Models;
namespace Marketing.Controllers
{
    public class OrderItemsController : Controller
    {
        // GET: OrderItems
        public ActionResult Index()
        {
            return View(OrderItems.GetAll());
        }
        public ActionResult CreateEdit(int OrderID)
        {
            OrderItems ObjOrder = new OrderItems();
            if(OrderID>0)
            {
                ObjOrder = ObjOrder.GetOne(OrderID);
            }
            return View(ObjOrder);
        }
        [HttpPost]
        public ActionResult CreateEdit(OrderItems ObjOrder)
        {
            int de = int.Parse(Request.QueryString["RagisID"]);
            ObjOrder.RagisID = de;
            int d = ObjOrder.Save();
            if (d > 0)
                return RedirectToAction("Index");
                return RedirectToAction("Index");
             
        }
        public ActionResult SaveItem(int buttonID,int RateValue,int Cars, string Name,int Username)
        {
            OrderItems ObjOrderItem = new OrderItems(); 
            ObjOrderItem.OrderID = 0;
            ObjOrderItem.ItemID = buttonID;
            ObjOrderItem.Prize = RateValue;
            ObjOrderItem.QTY = Cars;
            ObjOrderItem.Name = Name;
            ObjOrderItem.Count = 1;
            ObjOrderItem.RagisID = Username;
            ObjOrderItem.Save();
             
            return View();
        }
    }
}