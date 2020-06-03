using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.Models;
using Newtonsoft.Json.Linq;

namespace Marketing.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index( DateTime dateTime)
        {
            List<NewOrders> listneworder = new NewOrders().GetAll();
            var myDate = new DateTime(dateTime.Year, dateTime.Day, dateTime.Month);
            listneworder = listneworder.FindAll(x => x.Create_Date == myDate);
            return View(listneworder);
        }
        public ActionResult NewOrderIndex()
        {
            return View();
        }
        //public ActionResult SaveOrderItem(int ItemID,int Count,string Name,int Prize,int TotalRate,int Qty )
        //{
        //    Orders orders =  new Orders();
        //        orders.ItemID = ItemID;
        //        orders.ProductName = Name;
        //        orders.ProductPrize = Prize;
        //        orders.Qty = Qty.ToString();
        //        orders.TotalQty = Count;
        //        orders.PrizeTotal = TotalRate;
        //        orders.RagisID = 1;
        //        orders.Save();
        //    if(orders.OID>0)
        //    return RedirectToAction("ItemLoadFunction", "Home");
        //    return RedirectToAction("ItemLoadFunction", "Home");
        //}
        [HttpPost]
        public ActionResult CreateEdit([System.Web.Http.FromBody] Orders ObjItems)
        {
            Orders ObjItem = ObjItems;
            ObjItem.Save();
            List<NewOrders> listorder =  ObjItem.NewOrders;
            foreach(var order in listorder )
            {
                ObjItem.OID = order.OID;
                order.Save();
            }
            return  RedirectToAction("ItemLoadFunction","Home");

        }
    }
}